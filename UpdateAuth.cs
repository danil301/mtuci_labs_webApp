namespace mtuci_labs
{
    public class UpdateAuth
    {
        async public void Update()
        {
            var periodicTimer = new PeriodicTimer(TimeSpan.FromSeconds(3600));
            while (await periodicTimer.WaitForNextTickAsync())
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"Pages\IsAuth.txt"))
                {
                    file.Write("false");
                }
            }
        }
    }
}
