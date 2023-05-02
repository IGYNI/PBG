public interface IBrokable
{
    bool IsBroken { get; }
    void Broke();
    void Fix();
}