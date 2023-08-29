using BrainDump.Data.Entities;
using BrainDump.Interfaces;
using BrainDump.Validation;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace BrainDump.Clients
{
    public class GradeFactory
    {
        private readonly ICache<WholeGrade> _cache;
        private readonly Validator<WholeGrade> _validator;
        ValidationContext _validationContext;

        public GradeFactory(ICache<WholeGrade> classCache, Validator<WholeGrade> validator, ValidationContext validationContext)
        {
            _cache = classCache;
            _validator = validator;
            _validationContext = validationContext;
        }

        public WholeGrade? GiveMeGrade(string grade)
        {
            var gradeObject = new WholeGrade { Grade = grade, Id = new Guid() };
            _cache.Add(gradeObject);
            return gradeObject;
        }

    }
}
