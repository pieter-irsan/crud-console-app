using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Console_App
{
    class CRUD
    {
        Menu menu = new Menu();
        private Film film = new Film();
        public void Read()
        {
            Console.Clear();
            Console.WriteLine("Available Movies & Shows");
            List<Film> dataList = new List<Film>();
            if (File.Exists(Const.path))
            {
                string allText;
                FileStream fileStream = new FileStream(Const.path, FileMode.Open, FileAccess.Read);
                using (StreamReader streamReader = new StreamReader(fileStream, Encoding.UTF8))
                {
                    allText = streamReader.ReadToEnd();
                }
                string[] rows = allText.Split('|');
                foreach (string row in rows)
                {
                    if (row.Length > 0)
                    {
                        string[] columns = row.Split(',');
                        Film film = new Film
                        {
                            Title = columns[0],
                            Director = columns[1],
                            Release = columns[2],
                            Genre = columns[3].Replace("|", "")
                        };
                        dataList.Add(film);
                    }
                }
                foreach (Film film in dataList)
                {
                    Console.WriteLine();
                    Console.WriteLine("Title        : {0}", film.Title);
                    Console.WriteLine("Director     :{0}", film.Director);
                    Console.WriteLine("Release Date :{0}", film.Release);
                    Console.WriteLine("Genre        :{0}", film.Genre);
                }
            }
            else
            {
                Console.WriteLine(Const.path + " file is missing!");
            }
            Console.WriteLine();
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            menu.Option();
        }
        public void Write()
        {
            Console.Clear();
            if (File.Exists(Const.path))
            {
                Console.WriteLine("Add Film");
                Console.WriteLine("---------------------");
                Console.WriteLine("Title        : ");
                film.Title = Console.ReadLine();
                Console.WriteLine(" ");
                Console.WriteLine("Director     : ");
                film.Director = Console.ReadLine();
                Console.WriteLine(" ");
                Console.WriteLine("Release Date : ");
                film.Release = Console.ReadLine();
                Console.WriteLine(" ");
                Console.WriteLine("Genre        : ");
                film.Genre = Console.ReadLine();
                string array = film.Title + ", " + film.Director + ", " + film.Release + ", " + film.Genre + '|';
                File.AppendAllText(Const.path, array);
            }
            else
            {
                Console.WriteLine(Const.path + " file is missing!");
            }
            Console.WriteLine();
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            menu.Option();
        }
        public void Update()
        {
            Console.Clear();
            Console.WriteLine("Search by title ");
            Console.WriteLine("Notice: search is Case Sensitive!");
            string title = Console.ReadLine();
            List<Film> dataList = new List<Film>();
            if (File.Exists(Const.path))
            {
                string allText;
                FileStream fileStream = new FileStream(Const.path, FileMode.Open, FileAccess.Read);
                using (StreamReader streamReader = new StreamReader(fileStream, Encoding.UTF8))
                {
                    allText = streamReader.ReadToEnd();
                }
                string[] rows = allText.Split('|');
                foreach (string row in rows)
                {
                    if (row.Length > 0)
                    {
                        string[] columns = row.Split(',');
                        Film film = new Film();
                        film.Title = columns[0];
                        film.Director = columns[1];
                        film.Release = columns[2];
                        film.Genre = columns[3].Replace("|", "");
                        dataList.Add(film);
                    }
                }
                bool isFound = false;
                foreach (Film film in dataList)
                {
                    if (title == film.Title)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Title          : {0}", film.Title);
                        Console.WriteLine("*Edit title: ");
                        film.Title = Console.ReadLine();
                        Console.WriteLine();
                        Console.WriteLine("Director       :{0}", film.Director);
                        Console.WriteLine("*Edit director: ");
                        film.Director = Console.ReadLine();
                        Console.WriteLine();
                        Console.WriteLine("Release Date   :{0}", film.Release);
                        Console.WriteLine("*Edit release date: ");
                        film.Release = Console.ReadLine();
                        Console.WriteLine();
                        Console.WriteLine("Genre          :{0}", film.Genre);
                        Console.WriteLine("*Edit genre: ");
                        film.Genre = Console.ReadLine();
                        isFound = true;
                    }
                }
                if (!isFound)
                {
                    Console.WriteLine();
                    Console.WriteLine("Title not found");
                }
                using (StreamWriter streamWriter = new StreamWriter(Const.path))
                {
                    foreach (Film film in dataList)
                    {
                        streamWriter.Write("{0}, ", film.Title);
                        streamWriter.Write("{0}, ", film.Director);
                        streamWriter.Write("{0}, ", film.Release);
                        streamWriter.Write("{0}|", film.Genre);
                    }
                }
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine(Const.path + " file is missing!");
            }
            Console.WriteLine();
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            menu.Option();
        }
        public void Delete()
        {
            Console.Clear();
            Console.WriteLine("Enter title you with to delete");
            Console.WriteLine("Notice: title is Case Sensitive!");
            string title = Console.ReadLine();
            if (File.Exists(Const.path))
            {
                Console.WriteLine();
                Console.WriteLine("Delete is unavailable right now");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine(Const.path + " file is missing!");
            }
            Console.WriteLine();
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            menu.Option();
        }
        public void Search()
        {
            Console.Clear();
            Console.WriteLine("Search by title ");
            Console.WriteLine("Notice: search is Case Sensitive!");
            string title = Console.ReadLine();
            List<Film> dataList = new List<Film>();
            if (File.Exists(Const.path))
            {
                string allText;
                FileStream fileStream = new FileStream(Const.path, FileMode.Open, FileAccess.Read);
                using (StreamReader streamReader = new StreamReader(fileStream, Encoding.UTF8))
                {
                    allText = streamReader.ReadToEnd();
                }
                string[] rows = allText.Split('|');
                foreach (string row in rows)
                {
                    if (row.Length > 0)
                    {
                        string[] columns = row.Split(',');
                        Film film = new Film
                        {
                            Title = columns[0],
                            Director = columns[1],
                            Release = columns[2],
                            Genre = columns[3].Replace("|", "")
                        };
                        dataList.Add(film);
                    }
                }
                bool isFound = false;
                foreach (Film film in dataList)
                {
                    if (film.Title.Contains(title))
                    {
                        Console.WriteLine();
                        Console.WriteLine("Title        : {0}", film.Title);
                        Console.WriteLine("Director     :{0}", film.Director);
                        Console.WriteLine("Release Date :{0}", film.Release);
                        Console.WriteLine("Genre        :{0}", film.Genre);
                        isFound = true;
                    }
                }
                if (!isFound)
                {
                    Console.WriteLine();
                    Console.WriteLine("Film not found");
                }
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine(Const.path + " file is missing!");
            }
            Console.WriteLine();
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            menu.Option();
        }
    }
}
