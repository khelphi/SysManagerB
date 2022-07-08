using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace SysManager.Application.Helpers
{
    public interface IValidationRepository<TEntity, TRepository> where TEntity : class where TRepository : class
    {
        ValidationFailure Validate(TEntity entity, TRepository repository);
    }
}
