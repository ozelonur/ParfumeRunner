using _GAME_.Scripts.Enums;

namespace _GAME_.Scripts.Interfaces
{
    public interface IGate
    {
        public GateType GateType { get; set; }
        public int Worth { get; set; }

        void GateHit(params object[] args);
    }
}