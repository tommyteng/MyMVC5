using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace MyWebApi.Controllers
{
    /// <summary>
    /// Values
    /// </summary>
    [RoutePrefix("api/Values")]
    [EnableCors(origins: "http://localhost:16202", headers: "*", methods: "GET,POST,PUT,DELETE")]
    public class ValuesController : ApiController
    {

        /// <summary>
        /// Get方法
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

       /// <summary>
       /// 根据ID查询
       /// </summary>
       /// <param name="id">ID</param>
       /// <returns></returns>
       [Route("{id:decimal}")]
        public string Get(decimal id)
        {
            return "value";
        }

        /// <summary>
        /// GetV2
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        [Route("V2/{id:int=3}")]
        public string GetV2(int id)
        {
            return "value Get V2";
        }
        /// <summary>
        /// GetById 范围（5,10）
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        [Route("GetById/{id:range(5,10)}")]
        public string GetById(int id)
        {
            return "value GetById";
        }

        /// <summary>
        /// 根据name获取value
        /// </summary>
        /// <param name="name">Name</param>
        /// <returns></returns>
        [Route("{name:length(5,10):alpha}")]
        public string GetByName(string name)
        {
            return "valueName GetByName";
        }
        /// <summary>
        /// 根据ShortName获取value
        /// </summary>
        /// <param name="name">ShortName</param>
        /// <returns></returns>
        [Route("ShortName/{name}")]
        public string GetByShortName(string name)
        {
            return "valueName GetByShortName";
        }
        /// <summary>
        ///  根据MiddleName获取value
        /// </summary>
        /// <param name="name">MiddleName</param>
        /// <returns></returns>
        [Route("~/api/values/MiddleName/{name}")]
        public string GetByMiddleName(string name)
        {
            return "valueName GetByMiddleName";
        }


        /// <summary>
        /// POST
        /// </summary>
        /// <param name="value">value</param>
        [Route("")]
        public void Post([FromBody]string value)
        {
        }

        /// <summary>
        /// Put
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="value">value</param>
        [Route("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id">id</param>
        [Route("{id}")]
        public void Delete(int id)
        {
        }

        #region 内联约束
        //  内联约束类型      RouteConstraint类型                               说明
        //    int             IntRouteConstraint             要求路由参数值可能解析为一个int整数，比如{variable:int}
        //    bool            BoolRouteConstraint            要求参数值可以解析为一个bool值，比如{ variable:bool}
        //    datetime        DateTimeRouteConstraint        要求参数值可以解析为一个DateTime对象（采用CultureInfo.InvariantCulture进行解析），比如{ variable:datetime}
        //    decimal         DecimalRouteConstraint         要求参数值可以解析为一个decimal数字，比如{ variable:decimal}
        //    double          DoubleRouteConstraint          要求参数值可以解析为一个double数字，比如{ variable:double}
        //    float           FloatRouteConstraint           要求参数值可以解析为一个float数字，比如{ variable:float}
        //    guid            GuidRouteConstraint            要求参数值可以解析为一个Guid，比如{ variable:guid}
        //    long            LongRouteConstraint            要求参数值可以解析为一个long整数，比如{ variable:long}
        //    minlength       MinLengthRouteConstraint       要求参数值表示的字符串不于指定的长度{ variable:minlength(5)}
        //    maxlength       MaxLengthRouteConstraint       要求参数值表示的字符串不大于指定的长度，比如{ variable:maxlength(10)}
        //    length          LengthRouteConstraint          要求参数值表示的字符串长度限于指定的区间范围，比如{ variable:length(5,10)}
        //    min             MinRouteConstraint             要求参数值不于指定的值，比如{ variable:min(5)}
        //    max             MaxRouteConstraint             要求参数值大于指定的值，比如{ variable:max(10)}
        //    range           RangeouteConstraint            要求参数值介于指定的区间范围，比如{variable:range(5,10)}
        //    alpha           AlphaRouteContraint            要求参数值得所有字符都是字母，比如{variable:alpha}
        //    regex           RegexInlineRouteConstraint     要求参数值表示字符串与指定的正则表达式相匹配，比如{variable:regex(^d{ 0[0 - 9]{ { 2,3} -d{ 2} -d{ 4}$)} }}$)}
        //    required        RequiredRouteConstraint        要求参数值不应该是一个空字符串，比如{variable:required}
        #endregion
    }
}
