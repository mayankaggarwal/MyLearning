namespace algorithms.Common
{
    public interface IProjIO
    {
         void WriteBatch(params string[] message);
         void Write(string message);
         void WriteLine(string message);
         string Read();
    }
}