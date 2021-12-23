namespace Console_App
{
    public class Film
    {
        private string title;
        private string director;
        private string release;
        private string genre;
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        public string Director
        {
            get { return director; }
            set { director = value; }
        }
        public string Release
        {
            get { return release; }
            set { release = value; }
        }
        public string Genre
        {
            get { return genre; }
            set { genre = value; }
        }
    }
}
