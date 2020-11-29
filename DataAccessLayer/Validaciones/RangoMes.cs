using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DataAccessLayer.Validaciones
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class RangoMes : RangeAttribute, IClientValidatable
    {
        public RangoMes(int from) : base(from, DateTime.Today.Month) { }

        #region IClientValidatable Members

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rules = new ModelClientValidationRangeRule(this.ErrorMessage, this.Minimum, this.Maximum);
            yield return rules;
        }

        #endregion
    }
}
