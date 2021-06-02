using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cube.Models;

namespace Cube
{
    public class ItCubeContext : DbContext
    {
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Answer> Answers { get; set; }
        public virtual DbSet<Child> Childs { get; set; }
        public virtual DbSet<CinChild> CinChildrens { get; set; }
        public virtual DbSet<ConnectionGroup> ConnectionGroups { get; set; }
        public virtual DbSet<Equipment> Equipments { get; set; }
        public virtual DbSet<EquipmentGroup> EquipmentGroups { get; set; }
        public virtual DbSet<EquipmentGroupType> EquipmentGroupTypes { get; set; }
        public virtual DbSet<EquipmentMovementHistory> EquipmentMovementHistories { get; set; }
        public virtual DbSet<EquipmentsInServiceNote> EquipmentsInServiceNotes { get; set; }
        public virtual DbSet<EquipmentStatuse> EquipmentStatuses { get; set; }
        public virtual DbSet<EquipmentType> EquipmentTypes { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<Gender> Genders { get; set; }
        public virtual DbSet<Group> Group { get; set; }
        public virtual DbSet<GroupChild> GroupChilds { get; set; }
        public virtual DbSet<GroupOfChildren> GroupOfChilds{ get; set; }
        public virtual DbSet<Groups> Groups { get; set; }
        public virtual DbSet<Lession> Lessions { get; set; }
        public virtual DbSet<LessionChild> LessionChilds { get; set; }
        public virtual DbSet<LessionEmployee> LessionEmployees { get; set; }
        public virtual DbSet<Level> Levels { get; set; }
        public virtual DbSet<Module> Modules { get; set; }
        public virtual DbSet<ModuleChild> ModuleChilds{ get; set; }
        public virtual DbSet<ModuleTest> ModuleTests { get; set; }
        public virtual DbSet<Passport> Passports { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<QuestionAnswer> QuestionAnswers { get; set; }
        public virtual DbSet<Result> Results { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<SelectGroup> SelectGroups { get; set; }
        public virtual DbSet<ServiceNote> ServiceNotes { get; set; }
        public virtual DbSet<StaffEvent> StaffEvents { get; set; }
        public virtual DbSet<Statuse> Statuses { get; set; }
        public virtual DbSet<Test> Tests { get; set; }
        public virtual DbSet<TestQuest> TestQuests { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserInEvent> UserInEvents { get; set; }
        public virtual DbSet<UserPost> UserPosts { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }  
        
        public ItCubeContext(DbContextOptions<ItCubeContext> options) : base(options) { }
    }
}
