// <auto-generated />
namespace MMM.Model.Migrations
{
    using System.CodeDom.Compiler;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Migrations.Infrastructure;
    using System.Resources;
    
    [GeneratedCode("EntityFramework.Migrations", "6.1.3-40302")]
    public sealed partial class AddedBankAccountToTransactionAndChangedCreatedToSetDate : IMigrationMetadata
    {
        private readonly ResourceManager Resources = new ResourceManager(typeof(AddedBankAccountToTransactionAndChangedCreatedToSetDate));
        
        string IMigrationMetadata.Id
        {
            get { return "201707311935249_AddedBankAccountToTransactionAndChangedCreatedToSetDate"; }
        }
        
        string IMigrationMetadata.Source
        {
            get { return null; }
        }
        
        string IMigrationMetadata.Target
        {
            get { return Resources.GetString("Target"); }
        }
    }
}