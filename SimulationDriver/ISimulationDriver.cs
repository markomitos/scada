namespace SimulationDriver;

public interface ISimulationDriver
{
    void StartSimulation();
    void StopSimulation();
    double GetSignalValue(string ioAddress);
    void AddSignal(string ioAddress, SignalType signalType);
    void RemoveSignal(string ioAddress);
}

public enum SignalType
{
    Sinus,
    Cosinus,
    Ramp
}