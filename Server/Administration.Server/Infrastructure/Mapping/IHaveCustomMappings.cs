namespace Administration.Server.Infrastructure.Mapping
{
    using AutoMapper;
    public interface IHaveCustomMappings
    {
        void CreateMappings(IProfileExpression configuration);
    }
}
