namespace FIAP.Hackaton.OES.User.Infra.CorrelationId;

public interface ICorrelationIdGenerator
{
    string Get();
    void Set(string correlationId);
}
