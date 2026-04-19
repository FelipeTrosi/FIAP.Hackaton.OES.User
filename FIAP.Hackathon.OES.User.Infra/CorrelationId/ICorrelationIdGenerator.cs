namespace FIAP.Hackathon.OES.User.Infra.CorrelationId;

public interface ICorrelationIdGenerator
{
    string Get();
    void Set(string correlationId);
}
