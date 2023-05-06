using AutoMapper;
namespace HackTest.Application.Common.Interfaces;
public interface IMapFrom<T>
{
    void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());

}
