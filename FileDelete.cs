namespace mtuci_labs
{
    public class FileDelete
    {
        public string ReadAuth()
        {
            string Auth = File.ReadAllText(@"Pages\IsAuth.txt");
            return Auth;
        }
        public void FileDeleteFromFoler(string FilePath)
        {
            var f = Directory.GetFiles("uploads/", $"{FilePath}");
            File.Delete(f[0]);
            
        }
    }
}
