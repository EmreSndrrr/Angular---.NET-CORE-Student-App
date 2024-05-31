using AutoMapper;
using StudentManagement.DomainModels;

namespace StudentManagement.Profiles.AfterMap
{
    public class UpdateStudentRequestAfterMap : IMappingAction<UpdateStudentRequest, DataModels.Student>
    {
        public void Process(UpdateStudentRequest source, DataModels.Student destination, ResolutionContext context)
        {
            destination.Address = new DataModels.Address()
            {
                PhysicalAdress = source.PhysicalAdress,
                PostalAdress = source.PostalAdress
            };
        }
    }
}
