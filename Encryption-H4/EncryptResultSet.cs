namespace SimpleEncrypt
{
    public class EncryptResultSet
    {
        private long ticksElapsed;

        public long TicksElapsed
        {
            get { return ticksElapsed; }
            set { ticksElapsed = value; }
        }

        private List<string> results;

        public List<string> Data
        {
            get { return results; }
            set { results = value; }
        }


        public EncryptResultSet(long ticksElapsed, List<string> results)
        {
            this.ticksElapsed = ticksElapsed;
            this.results = results;
        }

        public EncryptResultSet()
        {
            this.results = new List<string>();
        }
    }
}