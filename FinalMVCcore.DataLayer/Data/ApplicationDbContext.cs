using FinalMVCcore.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FinalMVCcore.DataLayer.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(
			DbContextOptions<ApplicationDbContext> options) : base(options)
		{

		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.Ignore<SelectListGroup>();
			modelBuilder.Ignore<SelectListItem>();


		}
		public DbSet<Planta> Plantas { get; set; }
		public DbSet<TipoDePlanta> TiposDePlantas { get; set; }
	}
}
