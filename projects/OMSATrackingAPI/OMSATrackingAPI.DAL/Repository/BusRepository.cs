﻿using OMSATrackingAPI.DAL.Data;
using OMSATrackingAPI.DAL.Models;
using OMSATrackingAPI.DAL.Repository.Core;
using OMSATrackingAPI.DAL.Repository.IRepository;

namespace OMSATrackingAPI.DAL.Repository
{
    public class BusRepository : BaseRepository<Bus>, IBusRepository
    {
        public BusRepository(MainDbContext context) : base(context)
        {
        }
    }
}
