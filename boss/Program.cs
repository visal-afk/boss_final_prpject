using System.Text;
using boss.UnitOfWork.Concrets;
using boss.Persons;
using boss.Exceptions;
using boss.CV;

Console.InputEncoding = Encoding.UTF8;
Console.OutputEncoding = Encoding.UTF8;

BossDb db = new BossDb();
UnitOfWork uow = new UnitOfWork(db);

while (true)
{
    Console.Clear();
    Console.WriteLine("======= BOSS.AZ =======");
    Console.WriteLine("1. Giriş (Login)");
    Console.WriteLine("2. Qeydiyyat (Sign Up)");
    Console.WriteLine("0. Çıxış");
    Console.Write("\nSeçiminiz: ");

    string mainChoice = Console.ReadLine();
    if (mainChoice == "0") break;

    try
    {
        if (mainChoice == "1") 
        {
            Console.WriteLine("\n--- Giriş Növü ---");
            Console.WriteLine("1. İşçi | 2. İşəgötürən");
            string loginType = Console.ReadLine();

            Console.Write("Username: "); string user = Console.ReadLine();
            Console.Write("Password: "); string pass = Console.ReadLine();

            if (loginType == "1")
            {
                Worker worker = uow.AuthService.LoginWorker(user, pass);
                WorkerMenu(worker, uow);
            }
            else
            {
                Employer employer = uow.AuthService.LoginEmployer(user, pass);
                EmployerMenu(employer, uow);
            }
        }
        else if (mainChoice == "2") 
        {
            RegisterUser(uow);
        }
    }
    catch (Exception ex) { ShowError(ex.Message); }
}

void WorkerMenu(Worker worker, UnitOfWork uow)
{
    while (true)
    {
        Console.Clear();
        Console.WriteLine($"--- İşçi: {worker.name} ---");
        Console.WriteLine("1. Vakansiyalara Bax və CV Göndər");
        Console.WriteLine("2. CV Yarat / Yenilə");
        Console.WriteLine("0. Geri");
        string choice = Console.ReadLine();
        if (choice == "0") break;

        if (choice == "1")
        {
            var vacancies = uow.VacansiService.GetAll();
            foreach (var v in vacancies)
                Console.WriteLine($"ID: {v.Id} | {v.Title} | Maaş: {v.Salary} AZN");

            Console.Write("\nMüraciət üçün Vakansiya ID-sini daxil edin: ");
            if (int.TryParse(Console.ReadLine(), out int vacId))
            {
                var selectedVac = vacancies.FirstOrDefault(v => v.Id == vacId);
                if (selectedVac != null)
                {
                    if (worker.cv == null) Console.WriteLine("Xəta: Əvvəlcə CV yaratmalısınız!");
                    else
                    {
                        
                        selectedVac.IncomingCvs.Add(worker.cv);
                        uow.Save();
                        Console.WriteLine("CV uğurla göndərildi!");
                    }
                }
                else Console.WriteLine("Belə bir vakansiya tapılmadı!");
            }
            Console.ReadKey();
        }
        else if (choice == "2")
        {
            Console.WriteLine("\n--- CV Məlumatları ---");
            Console.Write("İxtisas: "); string ix = Console.ReadLine();
            Console.Write("Məktəb: "); string mk = Console.ReadLine();
            Console.Write("Universitet balı: "); int bal = int.Parse(Console.ReadLine());
            Console.Write("Bacarıqlar (vergüllə): "); List<string> skills = Console.ReadLine().Split(',').ToList();
            Console.Write("Şirkətlər (vergüllə): "); List<string> comps = Console.ReadLine().Split(',').ToList();
            Console.Write("Başlama ili: "); int sYear = int.Parse(Console.ReadLine());
            Console.Write("Bitmə ili: "); int eYear = int.Parse(Console.ReadLine());
            Console.Write("Dillər (vergüllə): "); List<string> langs = Console.ReadLine().Split(',').ToList();
            Console.Write("Fərqlənmə diplomu (y/n): "); bool dip = Console.ReadLine().ToLower() == "y";
            Console.Write("GitHub: "); string git = Console.ReadLine();
            Console.Write("LinkedIn: "); string link = Console.ReadLine();

            worker.cv = new Cv(ix, mk, bal, skills, comps, sYear, eYear, langs, dip, git, link);
            uow.Save();
            Console.WriteLine("CV uğurla yadda saxlanıldı!"); Console.ReadKey();
        }
    }
}


void EmployerMenu(Employer employer, UnitOfWork uow)
{
    while (true)
    {
        Console.Clear();
        Console.WriteLine($"--- Şirkət Paneli: {employer.name} ---");
        Console.WriteLine("1. Yeni Vakansiya Paylaş");
        Console.WriteLine("2. Paylaşdığım Vakansiyalara və Gələn CV-lərə Bax");
        Console.WriteLine("3. Vakansiyanı Sil");
        Console.WriteLine("0. Geri");
        string choice = Console.ReadLine();
        if (choice == "0") break;

        if (choice == "1")
        {
            Console.Write("Başlıq: "); string t = Console.ReadLine();
            Console.Write("Təsvir: "); string d = Console.ReadLine();
            Console.Write("Maaş: "); double s = double.Parse(Console.ReadLine());
            Console.Write("Kateqoriya: "); string c = Console.ReadLine();

            Vacansi newVac = new Vacansi(t, d, s, c);
            uow.VacansiService.Add(newVac);
            employer.Vacancies.Add(newVac);
            uow.Save();
            Console.WriteLine("Vakansiya paylaşıldı!"); Console.ReadKey();
        }
        else if (choice == "2")
        { 
            var allVacancies = uow.VacansiService.GetAll();
            var myVacs = allVacancies.Where(v => employer.Vacancies.Any(ev => ev.Id == v.Id)).ToList();
            Console.WriteLine("\n--- Sizin Vakansiyalarınız və Müraciətlər ---");
            foreach (var v in employer.Vacancies)
            {
                Console.WriteLine($"\nVAKANSİYA: {v.Title} (Maaş: {v.Salary} AZN)");
                Console.WriteLine($"Gələn müraciət sayı: {v.IncomingCvs.Count}");

                foreach (var cv in v.IncomingCvs)
                {
                    Console.WriteLine($"\n[Müraciət Detalları]");
                    Console.WriteLine($"Sahibi: {cv.ixtisas} | Təhsil: {cv.mekteb} | Bal: {cv.unoversitetbal}");
                    Console.WriteLine($"Bacarıqlar: {string.Join(", ", cv.bacariqlar)}");
                    Console.WriteLine($"İş təcrübəsi: {cv.isebaslamaqintarixi} - {cv.isibitmeTarixi}");
                    Console.WriteLine($"Dillər: {string.Join(", ", cv.diler)}");
                    Console.WriteLine($"LinkedIn: {cv.linkedin} | GitHub: {cv.gitlink}");
                }
            }
            Console.WriteLine("\nDavam etmək üçün bir düyməyə basın...");
            Console.ReadKey();
        }
        else if (choice == "3")
        {
            Console.Write("Silinəcək Vakansiya ID: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                uow.VacansiService.Delete(id);
                uow.Save(); Console.WriteLine("Vakansiya silindi.");
            }
            
        }
    }
}

void RegisterUser(UnitOfWork uow)
{
    Console.WriteLine("\n--- Qeydiyyat ---");
    Console.Write("Ad: "); string n = Console.ReadLine();
    Console.Write("Username: "); string u = Console.ReadLine();
    Console.Write("Password: "); string p = Console.ReadLine();
    Console.WriteLine("1. İşçi | 2. İşəgötürən");

    if (Console.ReadLine() == "1")
        uow.AuthService.RegisterWorker(new Worker(0, n, "S", "Bakı", 20, 111, u, p, null));
    else
        uow.AuthService.RegisterEmployer(new Employer(0, n, "S", "Bakı", 20, 111, u, p));

    uow.Save();
    Console.WriteLine("Qeydiyyat tamamlandı!"); Console.ReadKey();
}

void ShowError(string msg)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"\nXƏTA: {msg}");
    Console.ResetColor(); 
    Console.ReadKey();
}