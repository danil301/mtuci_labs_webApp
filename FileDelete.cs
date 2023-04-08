namespace mtuci_labs
{
    public class FileDelete
    {
        public string ReadAuth()
        {
            string Auth = File.ReadAllText(@"D:\VS\mtuci_project\Pages\IsAuth.txt");
            return Auth;
        }
        public void FileDeleteFromFoler(string FilePath)
        {
            var f = Directory.GetFiles("C:/Users/dvory/source/repos/mtuci_labs/uploads/", $"{FilePath}");
            File.Delete(f[0]);
            
        }
    }
}
