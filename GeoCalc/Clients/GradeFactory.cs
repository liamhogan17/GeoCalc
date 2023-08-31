using GeoCalc.Data.Entities;
using GeoCalc.Interfaces;
using GeoCalc.Validation;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace GeoCalc.Clients
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
            var gradeObject = new WholeGrade { Grade = grade };
            _cache.Add(gradeObject);
            return gradeObject;
        }

    }
}
