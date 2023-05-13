namespace daftarEventLibraries
{
    public class statusEvent
    {
        public String cekStatus(DateTime start , DateTime end)
        {
            DateTime t = DateTime.Now;
            if(start >= t && t < end)
            {
                return "Sedang Berlangsung";
            }
            else if(t < start)
            {
                return "Terjadwal";
            }
            else
            {
                return "Selesai";
            }
        }
    }
}