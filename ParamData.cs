using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battle_Param_Editor
{
    public class ParamData
    {
        public DataSet CreateDataStructure()
        {
            DataSet dsDataStructure = new DataSet("ParamDataStructure");

            DataTable dtPhysical = new DataTable("Physical");
            DataTable dtAttack = new DataTable("Attack");
            DataTable dtResist = new DataTable("Resist");
            DataTable dtMovement = new DataTable("Movement");

            dtPhysical.Columns.Add("Enemy Name", System.Type.GetType("System.String"));
            dtPhysical.Columns.Add("Offset", System.Type.GetType("System.UInt32"));
            dtPhysical.Columns.Add("Difficulty", System.Type.GetType("System.UInt32"));
            dtPhysical.Columns.Add("ATP", System.Type.GetType("System.UInt16"));
            dtPhysical.Columns.Add("MST", System.Type.GetType("System.UInt16"));
            dtPhysical.Columns.Add("EVP", System.Type.GetType("System.UInt16"));
            dtPhysical.Columns.Add("HP", System.Type.GetType("System.UInt16"));
            dtPhysical.Columns.Add("DFP", System.Type.GetType("System.UInt16"));
            dtPhysical.Columns.Add("ATA", System.Type.GetType("System.UInt16"));
            dtPhysical.Columns.Add("LCK", System.Type.GetType("System.UInt16"));
            dtPhysical.Columns.Add("ESP", System.Type.GetType("System.UInt16"));
            dtPhysical.Columns.Add("Range 1", System.Type.GetType("System.Single"));
            dtPhysical.Columns.Add("Range 2", System.Type.GetType("System.Single"));
            dtPhysical.Columns.Add("Boost", System.Type.GetType("System.UInt32"));
            dtPhysical.Columns.Add("XP", System.Type.GetType("System.UInt32"));
            dtPhysical.Columns.Add("TP", System.Type.GetType("System.UInt32"));
            dtPhysical.Columns["ATP"].DefaultValue = 0;
            dtPhysical.Columns["MST"].DefaultValue = 0;
            dtPhysical.Columns["EVP"].DefaultValue = 0;
            dtPhysical.Columns["HP"].DefaultValue = 0;
            dtPhysical.Columns["DFP"].DefaultValue = 0;
            dtPhysical.Columns["ATA"].DefaultValue = 0;
            dtPhysical.Columns["LCK"].DefaultValue = 0;
            dtPhysical.Columns["ESP"].DefaultValue = 0;
            dtPhysical.Columns["Range 1"].DefaultValue = 0.0f;
            dtPhysical.Columns["Range 2"].DefaultValue = 0.0f;
            dtPhysical.Columns["Boost"].DefaultValue = 0;
            dtPhysical.Columns["XP"].DefaultValue = 0;
            dtPhysical.Columns["TP"].DefaultValue = 0;
            dsDataStructure.Tables.Add(dtPhysical);

            dtAttack.Columns.Add("Enemy Name", System.Type.GetType("System.String"));
            dtAttack.Columns.Add("Offset", System.Type.GetType("System.UInt32"));
            dtAttack.Columns.Add("Difficulty", System.Type.GetType("System.UInt32"));
            dtAttack.Columns.Add("Angle X ", System.Type.GetType("System.Single"));
            dtAttack.Columns.Add("Unknown 1", System.Type.GetType("System.UInt16"));
            dtAttack.Columns.Add("Unknown 2", System.Type.GetType("System.UInt16"));
            dtAttack.Columns.Add("Unknown 3", System.Type.GetType("System.UInt16"));
            dtAttack.Columns.Add("Unknown 4", System.Type.GetType("System.UInt16"));
            dtAttack.Columns.Add("Distance X", System.Type.GetType("System.Single"));
            dtAttack.Columns.Add("Angle X", System.Type.GetType("System.UInt32"));
            dtAttack.Columns.Add("Distance Y", System.Type.GetType("System.Single"));
            dtAttack.Columns.Add("Unknown 6", System.Type.GetType("System.UInt32"));
            dtAttack.Columns.Add("Unknown 7", System.Type.GetType("System.UInt32"));
            dtAttack.Columns.Add("Unknown 8", System.Type.GetType("System.UInt32"));
            dtAttack.Columns.Add("Unknown 9", System.Type.GetType("System.UInt32"));
            dtAttack.Columns.Add("Unknown 10", System.Type.GetType("System.UInt32"));
            dtAttack.Columns.Add("Unknown 11", System.Type.GetType("System.UInt32"));
            dtAttack.Columns.Add("Unknown 12", System.Type.GetType("System.UInt32"));
            dtAttack.Columns["Unknown 1"].DefaultValue = 0;
            dtAttack.Columns["Unknown 2"].DefaultValue = 0;
            dtAttack.Columns["Unknown 3"].DefaultValue = 0;
            dtAttack.Columns["Distance X"].DefaultValue = 0.0f;
            dtAttack.Columns["Angle X"].DefaultValue = 0;
            dtAttack.Columns["Distance Y"].DefaultValue = 0.0f;
            dsDataStructure.Tables.Add(dtAttack);

            dtResist.Columns.Add("Enemy Name", System.Type.GetType("System.String"));
            dtResist.Columns.Add("Offset", System.Type.GetType("System.UInt32"));
            dtResist.Columns.Add("Difficulty", System.Type.GetType("System.UInt32"));
            dtResist.Columns.Add("Unknown 1", System.Type.GetType("System.UInt16"));
            dtResist.Columns.Add("EFR", System.Type.GetType("System.UInt16"));
            dtResist.Columns.Add("EIC", System.Type.GetType("System.UInt16"));
            dtResist.Columns.Add("ETH", System.Type.GetType("System.UInt16"));
            dtResist.Columns.Add("ELT", System.Type.GetType("System.UInt16"));
            dtResist.Columns.Add("EDK", System.Type.GetType("System.UInt16"));
            dtResist.Columns.Add("Reserved 1", System.Type.GetType("System.UInt32"));
            dtResist.Columns.Add("Reserved 2", System.Type.GetType("System.UInt32"));
            dtResist.Columns.Add("Reserved 3", System.Type.GetType("System.UInt32"));
            dtResist.Columns.Add("Reserved 4", System.Type.GetType("System.UInt32"));
            dtResist.Columns.Add("Reserved 5", System.Type.GetType("System.UInt32"));
            dtResist.Columns["EFR"].DefaultValue = 0;
            dtResist.Columns["EIC"].DefaultValue = 0;
            dtResist.Columns["ETH"].DefaultValue = 0;
            dtResist.Columns["ELT"].DefaultValue = 0;
            dtResist.Columns["EDK"].DefaultValue = 0;
            dsDataStructure.Tables.Add(dtResist);

            dtMovement.Columns.Add("Enemy Name", System.Type.GetType("System.String"));
            dtMovement.Columns.Add("Offset", System.Type.GetType("System.UInt32"));
            dtMovement.Columns.Add("Difficulty", System.Type.GetType("System.UInt32"));
            dtMovement.Columns.Add("Idle Move Speed", System.Type.GetType("System.Single"));
            dtMovement.Columns.Add("Idle Animation Speed", System.Type.GetType("System.Single"));
            dtMovement.Columns.Add("Move Speed", System.Type.GetType("System.Single"));
            dtMovement.Columns.Add("Animation Speed", System.Type.GetType("System.Single"));
            dtMovement.Columns.Add("Unknown 1", System.Type.GetType("System.Single"));
            dtMovement.Columns.Add("Unknown 2", System.Type.GetType("System.Single"));
            dtMovement.Columns.Add("Unknown 3", System.Type.GetType("System.UInt32"));
            dtMovement.Columns.Add("Unknown 4", System.Type.GetType("System.UInt32"));
            dtMovement.Columns.Add("Unknown 5", System.Type.GetType("System.UInt32"));
            dtMovement.Columns.Add("Unknown 6", System.Type.GetType("System.UInt32"));
            dtMovement.Columns.Add("Unknown 7", System.Type.GetType("System.UInt32"));
            dtMovement.Columns.Add("Unknown 8", System.Type.GetType("System.UInt32"));
            dtMovement.Columns["Idle Move Speed"].DefaultValue = 0.0f;
            dtMovement.Columns["Idle Animation Speed"].DefaultValue = 0.0f;
            dtMovement.Columns["Move Speed"].DefaultValue = 0;
            dtMovement.Columns["Animation Speed"].DefaultValue = 0;
            dsDataStructure.Tables.Add(dtMovement);

            return dsDataStructure;
        }

        public DataTable CreateConstants()
        {
            DataTable dtConstants = new DataTable("Constants");
            dtConstants.Columns.Add("Name", System.Type.GetType("System.String"));
            dtConstants.Columns.Add("Int", System.Type.GetType("System.Int32"));
            dtConstants.Columns.Add("Single", System.Type.GetType("System.Single"));
            dtConstants.Columns.Add("String", System.Type.GetType("System.String"));

            return dtConstants;
        }

        public DataTable CreatePointerStructure()
        {
            DataTable dtPointers = new DataTable("Pointers");
            dtPointers.Columns.Add("Table name", System.Type.GetType("System.String"));
            dtPointers.Columns.Add("Table address", System.Type.GetType("System.Int32"));

            return dtPointers;
        }
    }
}
