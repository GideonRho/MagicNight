namespace MagicNight.Models.Types
{
    public class RandomInt
    {

        public enum EType
        {
            Auto, Random, Value
        }

        public EType Type { get; set; }
        public int Value { get; set; }
        
    }
}