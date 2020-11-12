using ApiWebRest.Models;
using AutoMapper;
using DataAccessLayer.Modelos;
using Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiWebRest.Controllers
{
    public class ExpensasAWRController : ApiController
    {
        MapperConfiguration mapconfig;
        ContextoEntities contexto = new ContextoEntities();

        public ExpensasAWRController()
        {
            mapconfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DataAccessLayer.Modelos.sp_Expensas_Result, ExpensasDTO>();
            });
        }

        public IEnumerable<ExpensasDTO> Get(int id)
        {
            IMapper iMapper = mapconfig.CreateMapper();

            List<ExpensasDTO> listadoDTO = new List<ExpensasDTO>();

            foreach (sp_Expensas_Result expensa in contexto.sp_Expensas(id))
            {
                ExpensasDTO dto = iMapper.Map<DataAccessLayer.Modelos.sp_Expensas_Result, ExpensasDTO>(expensa);
                listadoDTO.Add(dto);
            }

            return listadoDTO;
        }
    }
}