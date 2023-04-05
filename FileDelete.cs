namespace mtuci_labs
{
    public class FileDelete
    {
        public void FileDeleteFromFoler(string FilePath)
        {
            var f = Directory.GetFiles("C:/Users/dvory/source/repos/mtuci_labs/uploads/", $"{FilePath}");
            File.Delete(f[0]);
        }
    }
}
