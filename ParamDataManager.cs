using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace Battle_Param_Editor
{
    public class ParamDataManager
    {
        #region Structs

        private struct TableLocation
        {
            public int startPosition;
            public int endPosition;
        };

        #endregion
        #region Variables
        public DataSet dsParamData = null;
        public List<int> physicalSizes = new List<int>() { 2, 2, 2, 2, 2, 2, 2, 2, 4, 4, 4, 4, 4 };
        public List<int> resistSizes = new List<int>() { 2, 2, 2, 2, 2, 2, 4, 4, 4, 4, 4 };
        public List<int> attackSizes = new List<int>() { 2, 2, 2, 2, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4 };
        public List<int> movementSizes = new List<int>() { 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4 };
        private int episode = 0;

        private readonly IList<string> paramTables = new List<string> {
                "Physical",
                "Attack",
                "Resist",
                "Movement"
            }.AsReadOnly();

        private readonly IList<string>[] ep1Names = {
                new List<string> { // Physical
                "MonthMant",
                "Monest",
                "Savage Wolf",
                "Barbarous Wolf",
                "Poison Lily",
                "Nar Lily",
                "Sinow Beat",
                "Canadine",
                "Canadine (Ring)",
                "Canane",
                "Chaos Sorcerer",
                "Bee R",
                "Bee L",
                "Chaos Bringer",
                "Dark Belra",
                "DE RO LE (Body)",
                "DE RO LE (Shell)",
                "DE RO LE (Tail Mine)",
                "DRAGON",
                "Sinow Gold",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "Rag Rappy",
                "AI Rappy",
                "Nano Dragon",
                "Dubchic",
                "Gillchic",
                "Garanz",
                "Dark Gunner",
                "Bul Claw",
                "Claw",
                "VOL OPT (Core)",
                "VOL OPT (Pillar )",
                "VOL OPT (Monitor)",
                "VOL OPT (Celing Amp)",
                "VOL OPT (2nd Core)",
                "VOL OPT (2nd Trap)",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "Pofuilly Slime",
                "Pan Arms",
                "Hidoom",
                "Migium",
                "Pouilly Slime",
                "Darvant (Mine Field)",
                "DARK FALZ (Phase 1)",
                "DARK FALZ (Phase 2)",
                "DARK FALZ (Phase 3)",
                "Darvant (Phase 2 Ult)",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "Dubswitch",
                "HildeBear",
                "HildeBlue",
                "Booma",
                "Go Booma",
                "Gigo Booma",
                "Grass Assasin",
                "Evil Shark",
                "Pal Shark",
                "Guil Shark",
                "Del Saber",
                "Dimenian",
                "La Dimenian",
                "So Dimenian",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID"
                }.AsReadOnly(),
                new List<string> { // Resist
                "MonthMant",
                "Monest",
                "Savage Wolf",
                "Barbarous Wolf",
                "Poison Lily",
                "Nar Lily",
                "Sinow Beat",
                "Canadine",
                "Canadine (Ring)",
                "Canane",
                "Chaos Sorcerer",
                "Bee R",
                "Bee L",
                "Chaos Bringer",
                "Dark Belra",
                "DE RO LE (Body)",
                "DE RO LE (Shell)",
                "DE RO LE (Tail Mine)",
                "DRAGON",
                "Sinow Gold",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "Rag Rappy",
                "AI Rappy",
                "Nano Dragon",
                "Dubchic",
                "Gillchic",
                "Garanz",
                "Dark Gunner",
                "Bul Claw",
                "Claw",
                "VOL OPT (Core)",
                "VOL OPT (Pillar )",
                "VOL OPT (Monitor)",
                "VOL OPT (Celing Amp)",
                "VOL OPT (2nd Core)",
                "VOL OPT (2nd Trap)",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "Pofuilly Slime",
                "Pan Arms",
                "Hidoom",
                "Migium",
                "Pouilly Slime",
                "Darvant (Mine Field)",
                "DARK FALZ (Phase 1)",
                "DARK FALZ (Phase 2)",
                "DARK FALZ (Phase 3)",
                "Darvant (Phase 2 Ult)",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "HildeBear",
                "HildeBlue",
                "Booma",
                "Go Booma",
                "Gigo Booma",
                "Grass Assasin",
                "Evil Shark",
                "Pal Shark",
                "Guil Shark",
                "Del Saber",
                "Dimenian",
                "La Dimenian",
                "So Dimenian",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID"
                }.AsReadOnly(),
                new List<string> { // Attack
                "MonthMant",
                "Monest",
                "Savage Wolf",
                "Barbarous Wolf",
                "Poison Lily Peck",
                "UNKNOWN",
                "Sinow Beat Punch",
                "UNKNOWN",
                "UNKNOWN",
                "UNKNOWN",
                "UNKNOWN",
                "UNKNOWN",
                "UNKNOWN",
                "UNKNOWN",
                "Chaos Bringer",
                "INVALID",
                "UNKNOWN",
                "UNKNOWN",
                "UNKNOWN",
                "UNKNOWN",
                "UNKNOWN",
                "UNKNOWN",
                "UNKNOWN",
                "UNKNOWN",
                "Rag Rappy Peck",
                "Al Rappy Peck",
                "INVALID",
                "Dubchic",
                "Gilchic",
                "INVALID",
                "INVALID",
                "Bul Claw",
                "Claw",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "Darvant (Mine Field)",
                "INVALID",
                "INVALID",
                "INVALID",
                "Darvant (Phase 2 Ult)",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "UNKNOWN",
                "HildeBear Punch",
                "HildeBear Tech",
                "HildeBear Jump",
                "HildeBlue Punch",
                "HildeBlue Tech",
                "HildeBlue Jump",
                "Booma Punch",
                "Go Booma Punch",
                "Giga Booma Punch",
                "Grass Assasin 1",
                "Grass Assasin 2",
                "Grass Assasin 3",
                "Evil Shark Punch",
                "Pal Shark Punch",
                "Guil Shark Punch",
                "Del Saber 1",
                "Del Saber 2",
                "Del Saber 3",
                "Dimenian Punch",
                "La Dimenian Punch",
                "So Dimenian Punch",
                "INVALID",
                "INVALID",
                "INVALID"
                }.AsReadOnly(),
                new List<string> { // Movement
                "MonthMant",
                "Monest",
                "Savage Wolf",
                "Barbarous Wolf",
                "Poison Lily",
                "Nar Lily",
                "Sinow Beat",
                "Canadine",
                "Canadine (Ring)",
                "Canane",
                "Chaos Sorcerer",
                "Bee R",
                "Bee L",
                "Chaos Bringer",
                "Dark Belra",
                "DE RO LE (Body)",
                "DE RO LE (Shell)",
                "DE RO LE (Tail Mine)",
                "DRAGON",
                "Sinow Gold",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "Rag Rappy",
                "AI Rappy",
                "Nano Dragon",
                "Dubchic",
                "Gillchic",
                "Garanz",
                "Dark Gunner",
                "Bul Claw",
                "Claw",
                "VOL OPT (Core)",
                "VOL OPT (Pillar )",
                "VOL OPT (Monitor)",
                "VOL OPT (Celing Amp)",
                "VOL OPT (2nd Core)",
                "VOL OPT (2nd Trap)",
                "UNKNOWN",
                "UNKNOWN",
                "UNKNOWN",
                "UNKNOWN",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "Pofuilly Slime",
                "Pan Arms",
                "Hidoom",
                "Migium",
                "Pouilly Slime",
                "Darvant (Mine Field)",
                "DARK FALZ (Phase 1)",
                "DARK FALZ (Phase 2)",
                "DARK FALZ (Phase 3)",
                "Darvant (Phase 2 Ult)",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "HildeBear",
                "HildeBlue",
                "Booma",
                "Go Booma",
                "Gigo Booma",
                "Grass Assasin",
                "Evil Shark",
                "Pal Shark",
                "Guil Shark",
                "Del Saber",
                "Dimenian",
                "La Dimenian",
                "So Dimenian",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID"
                }.AsReadOnly()
            };

        private readonly IList<string>[] ep2Names = {
                new List<string> { // Physical
                "Mothmant",
                "Monest",
                "Savage Wolf",
                "Barbarous Wolf",
                "Poison Lily",
                "Nar Lily",
                "Sinow Berill",
                "Gee",
                "UNKNOWN",
                "UNKNOWN",
                "Chaos Sorceror",
                "Bee R",
                "Bee L",
                "Delbiter",
                "Dark Belra",
                "Barba Ray",
                "Pig Ray",
                "Ul Ray",
                "Gol Dragon",
                "Sinow Spigell",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "Rag Rappy",
                "Love Rappy",
                "Gi Gue",
                "Dubchic",
                "Gillchic",
                "Garanz",
                "Gal Gryphon",
                "UNKNOWN",
                "UNKNOWN",
                "UNKNOWN",
                "UNKNOWN",
                "Epsilon",
                "Epsigard",
                "Del Lily",
                "Ill Gill",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "Olga Flow Phase 1",
                "Olga Flow Phase 2",
                "Gael",
                "Giel",
                "INVALID",
                "Deldepth",
                "Pan Arms",
                "Hidoom",
                "Migium",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "Mericarol",
                "Ul Gibbon",
                "Zol Gibbon",
                "Gibbles",
                "INVALID",
                "INVALID",
                "Morfos",
                "Recobox",
                "Recon",
                "Sinow Zoa",
                "Sinow Zele",
                "Merikle ",
                "Mericus",
                "INVALID",
                "INVALID",
                "Hildebear",
                "Hildeblue",
                "Merillia",
                "Meriltas",
                "INVALID",
                "Grass Assassin",
                "Dolmolm",
                "Dolmdarl",
                "UNKNOWN",
                "Delsaber",
                "Dimenian",
                "La Dimenian",
                "So Dimenian",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID"
                }.AsReadOnly(),
                new List<string> { // Resist
                "Mothmant",
                "Monest",
                "Savage Wolf",
                "Barbarous Wolf",
                "Poison Lily",
                "Nar Lily",
                "Sinow Berill",
                "Gee",
                "UNKNOWN",
                "UNKNOWN",
                "Chaos Sorceror",
                "Bee R",
                "Bee L",
                "Delbiter",
                "Dark Belra",
                "Barba Ray",
                "Pig Ray",
                "Ul Ray",
                "Gol Dragon",
                "Sinow Spigell",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "Rag Rappy",
                "Love Rappy",
                "Gi Gue",
                "Dubchic",
                "Gillchic",
                "Garanz",
                "Gal Gryphon",
                "UNKNOWN",
                "UNKNOWN",
                "UNKNOWN",
                "UNKNOWN",
                "Epsilon",
                "Epsigard",
                "Del Lily",
                "Ill Gill",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "Olga Flow Phase 1",
                "Olga Flow Phase 2",
                "Gael",
                "Giel",
                "INVALID",
                "Deldepth",
                "Pan Arms",
                "Hidoom",
                "Migium",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "Mericarol",
                "Ul Gibbon",
                "Zol Gibbon",
                "Gibbles",
                "INVALID",
                "INVALID",
                "Morfos",
                "Recobox",
                "Recon",
                "Sinow Zoa",
                "Sinow Zele",
                "Merikle ",
                "Mericus",
                "INVALID",
                "Hildebear",
                "Hildeblue",
                "Merillia",
                "Meriltas",
                "UNKNOWN",
                "Grass Assassin",
                "Dolmolm",
                "Dolmdarl",
                "UNKNOWN",
                "Delsaber",
                "Dimenian",
                "La Dimenian",
                "So Dimenian",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID"
                }.AsReadOnly(),
                new List<string> { // Attack
                "UNKNOWN",
                "UNKNOWN",
                "UNKNOWN",
                "UNKNOWN",
                "UNKNOWN",
                "UNKNOWN",
                "UNKNOWN",
                "UNKNOWN",
                "UNKNOWN",
                "UNKNOWN",
                "UNKNOWN",
                "UNKNOWN",
                "UNKNOWN",
                "UNKNOWN",
                "UNKNOWN",
                "UNKNOWN",
                "UNKNOWN",
                "UNKNOWN",
                "UNKNOWN",
                "UNKNOWN",
                "UNKNOWN",
                "UNKNOWN",
                "UNKNOWN",
                "UNKNOWN",
                "UNKNOWN",
                "UNKNOWN",
                "UNKNOWN",
                "UNKNOWN",
                "UNKNOWN",
                "UNKNOWN",
                "UNKNOWN",
                "UNKNOWN",
                "UNKNOWN",
                "UNKNOWN",
                "UNKNOWN",
                "UNKNOWN",
                "UNKNOWN",
                "UNKNOWN",
                "UNKNOWN",
                "UNKNOWN",
                "UNKNOWN",
                "UNKNOWN",
                "UNKNOWN",
                "UNKNOWN",
                "UNKNOWN",
                "UNKNOWN",
                "UNKNOWN",
                "UNKNOWN",
                "UNKNOWN",
                "UNKNOWN",
                "UNKNOWN",
                "UNKNOWN",
                "UNKNOWN",
                "UNKNOWN",
                "UNKNOWN",
                "UNKNOWN",
                "UNKNOWN",
                "UNKNOWN",
                "UNKNOWN",
                "UNKNOWN",
                "UNKNOWN",
                "UNKNOWN",
                "UNKNOWN",
                "UNKNOWN",
                "UNKNOWN",
                "UNKNOWN",
                "UNKNOWN",
                "UNKNOWN",
                "UNKNOWN",
                "UNKNOWN",
                "UNKNOWN",
                "UNKNOWN",
                "UNKNOWN",
                "UNKNOWN",
                "UNKNOWN",
                "UNKNOWN",
                "UNKNOWN",
                "UNKNOWN",
                "UNKNOWN",
                "UNKNOWN",
                "UNKNOWN",
                "UNKNOWN",
                "UNKNOWN",
                "UNKNOWN",
                "UNKNOWN",
                "UNKNOWN",
                "UNKNOWN",
                "UNKNOWN",
                "UNKNOWN",
                "UNKNOWN",
                "UNKNOWN",
                "UNKNOWN",
                "UNKNOWN",
                "UNKNOWN",
                "UNKNOWN",
                "UNKNOWN"
                }.AsReadOnly(),
                new List<string> { // Movement
                "Mothmant",
                "Monest",
                "Savage Wolf",
                "Barbarous Wolf",
                "Poison Lily",
                "Nar Lily",
                "Sinow Berill",
                "Gee",
                "UNKNOWN",
                "UNKNOWN",
                "Chaos Sorceror",
                "Bee R",
                "Bee L",
                "Delbiter",
                "Dark Belra",
                "Barba Ray",
                "Pig Ray",
                "Ul Ray",
                "Gol Dragon",
                "Sinow Spigell",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "Rag Rappy",
                "Love Rappy",
                "Gi Gue",
                "Dubchic",
                "Gillchic",
                "Garanz",
                "Gal Gryphon",
                "UNKNOWN",
                "UNKNOWN",
                "UNKNOWN",
                "UNKNOWN",
                "Epsilon",
                "Epsigard",
                "Del Lily",
                "Ill Gill",
                "UNKNOWN",
                "UNKNOWN",
                "UNKNOWN",
                "UNKNOWN",
                "Olga Flow Phase 1",
                "Olga Flow Phase 2",
                "Gael",
                "Giel",
                "INVALID",
                "Deldepth",
                "Pan Arms",
                "Hidoom",
                "Migium",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "Mericarol",
                "Ul Gibbon",
                "Zol Gibbon",
                "Gibbles",
                "INVALID",
                "INVALID",
                "Morfos",
                "Recobox",
                "Recon",
                "Sinow Zoa",
                "Sinow Zele",
                "Merikle ",
                "Mericus",
                "INVALID",
                "Hildebear",
                "Hildeblue",
                "Merillia",
                "Meriltas",
                "UNKNOWN",
                "Grass Assassin",
                "Dolmolm",
                "Dolmdarl",
                "UNKNOWN",
                "Delsaber",
                "Dimenian",
                "La Dimenian",
                "So Dimenian",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID"
                }.AsReadOnly()
            };

        private readonly IList<string>[] ep4Names = {
                new List<string> { // Physical
                "Boota (Crater)",
                "Ze Boota (Crater)",
                "INVALID",
                "Ba Boota (Crater)",
                "INVALID",
                "Sand Rappy (Crater)",
                "Del Rappy (Crater)",
                "Zu (Crater)",
                "Pazuzu (Crater)",
                "Astark (Crater)",
                "INVALID",
                "INVALID",
                "INVALID",
                "Satellite Lizard (Crater)",
                "Yowie (Crater)",
                "Dorphon (Crater)",
                "Dorphon Éclair (Crater)",
                "Goran (Desert)",
                "Pyro Goran (Desert)",
                "Goran Detonator (Desert)",
                "INVALID",
                "INVALID",
                "INVALID",
                "Sand Rappy (Desert)",
                "Del Rappy (Desert)",
                "Merissa A (Desert)",
                "Merissa AA (Desert)",
                "Zu (Desert)",
                "Pazuzu (Desert)",
                "Satellite Lizard (Desert)",
                "Yowie (Desert)",
                "Girtablulu (Desert)",
                "Saint-Million (Part 1)",
                "Spinning thing",
                "Saint-Million (Part 2)",
                "Spinning thing",
                "Shambertin (Part 1)",
                "Spinning thing",
                "Shambertin (Part 2)",
                "Spinning thing",
                "Kondrieu (Part 1)",
                "Spinning thing",
                "Kondrieu (Part 2)",
                "Spinning thing",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID"
                }.AsReadOnly(),
            new List<string> { // Resist
                "Boota (Crater)",
                "Ze Boota (Crater)",
                "INVALID",
                "Ba Boota (Crater)",
                "INVALID",
                "Sand Rappy (Crater)",
                "Del Rappy (Crater)",
                "Zu (Crater)",
                "Pazuzu (Crater)",
                "Astark (Crater)",
                "INVALID",
                "INVALID",
                "INVALID",
                "Satellite Lizard (Crater)",
                "Yowie (Crater)",
                "Dorphon (Crater)",
                "Dorphon Éclair (Crater)",
                "Goran (Desert)",
                "Pyro Goran (Desert)",
                "Goran Detonator (Desert)",
                "INVALID",
                "INVALID",
                "INVALID",
                "Sand Rappy (Desert)",
                "Del Rappy (Desert)",
                "Merissa A (Desert)",
                "Merissa AA (Desert)",
                "Zu (Desert)",
                "Pazuzu (Desert)",
                "Satellite Lizard (Desert)",
                "Yowie (Desert)",
                "Girtablulu (Desert)",
                "Saint-Million (Part 1)",
                "Spinning thing",
                "Saint-Million (Part 2)",
                "Spinning thing",
                "Shambertin (Part 1)",
                "Spinning thing",
                "Shambertin (Part 2)",
                "Spinning thing",
                "Kondrieu (Part 1)",
                "Spinning thing",
                "Kondrieu (Part 2)",
                "Spinning thing",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID"
                }.AsReadOnly(),
            new List<string> { // Attack
                "Boota 1",
                "Boota 2",
                "Boota 3",
                "Ze Boota 1",
                "Ze Boota 2",
                "Sand Rappy (Crater)",
                "Del Rappy (Crater)",
                "Zu (Crater)",
                "Pazuzu (Crater)",
                "Astark (Crater)",
                "Astark Punch",
                "Astark Poison",
                "Astark Jump",
                "Satellite Lizard (Crater)",
                "Yowie (Crater)",
                "UNKNOWN",
                "UNKNOWN",
                "UNKNOWN",
                "UNKNOWN",
                "UNKNOWN",
                "Goran (Desert)",
                "Pyro Goran (Desert)",
                "Goran Detonator (Desert)",
                "Sand Rappy (Desert)",
                "Del Rappy (Desert)",
                "Merissa A (Desert)",
                "Merissa AA (Desert)",
                "Zu (Desert)",
                "Pazuzu (Desert)",
                "Satellite Lizard (Desert)",
                "Yowie (Desert)",
                "Girtablulu (Desert)",
                "Saint-Million 1",
                "Saint-Million 2",
                "Saint-Million 3",
                "Saint-Million 4",
                "Shambertin 1",
                "Shambertin 2",
                "Shambertin 3",
                "Shambertin 4",
                "Kondrieu 1",
                "Kondrieu 2",
                "Kondrieu 3",
                "Kondrieu 4",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID"
                }.AsReadOnly(),
            new List<string> { // Movement
                "Boota (Crater)",
                "Ze Boota (Crater)",
                "INVALID",
                "Ba Boota (Crater)",
                "INVALID",
                "Sand Rappy (Crater)",
                "Del Rappy (Crater)",
                "Zu (Crater)",
                "Pazuzu (Crater)",
                "Astark (Crater)",
                "INVALID",
                "INVALID",
                "INVALID",
                "Satellite Lizard (Crater)",
                "Yowie (Crater)",
                "Dorphon (Crater)",
                "Dorphon Éclair (Crater)",
                "Goran (Desert)",
                "Pyro Goran (Desert)",
                "Goran Detonator (Desert)",
                "INVALID",
                "INVALID",
                "INVALID",
                "Sand Rappy (Desert)",
                "Del Rappy (Desert)",
                "Merissa A (Desert)",
                "Merissa AA (Desert)",
                "Zu (Desert)",
                "Pazuzu (Desert)",
                "Satellite Lizard (Desert)",
                "Yowie (Desert)",
                "Girtablulu (Desert)",
                "Saint-Million 1",
                "Saint-Million 2",
                "Saint-Million 3",
                "Saint-Million 4",
                "Shambertin 1",
                "Shambertin 2",
                "Shambertin 3",
                "Shambertin 4",
                "Kondrieu 1",
                "Kondrieu 2",
                "Kondrieu 3",
                "Kondrieu 4",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID",
                "INVALID"
                }.AsReadOnly()
            };

        #endregion
        #region Load Data
        public DataSet LoadParamData(string fileName)
        {
            ParamData paramData = new ParamData();
            dsParamData = paramData.CreateDataStructure();


            using (FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                // Get Difficulty Table Count
                BinaryReader reader = new BinaryReader(stream);
                uint difficultyTableCount = Convert.ToUInt32(stream.Length / 15744);
#if (PUBLICRELEASE)
                if(difficultyTableCount != 4)
                {
                    return null;
                }
#endif
                // Set Constants Table
                DataTable dtConstants = paramData.CreateConstants();
                dtConstants.Rows.Add(new object[] { "DifficultyCount", difficultyTableCount, null, null });
                dsParamData.Tables.Add(dtConstants);

                // Load Table Pointers
                DataTable dtTablePointers = paramData.CreatePointerStructure();
                dtTablePointers.Rows.Add(new object[] { "Physical", 0 });
                dtTablePointers.Rows.Add(new object[] { "Attack", (3456 * difficultyTableCount) });
                dtTablePointers.Rows.Add(new object[] { "Resist", ((3456 + 4608) * difficultyTableCount) });
                dtTablePointers.Rows.Add(new object[] { "Movement", ((3456 + 3072 + 4608) * difficultyTableCount) });
                dsParamData.Tables.Add(dtTablePointers);
            }

            using (FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                int size = (int)stream.Length;
                byte[] data = new byte[size];
                stream.Read(data, 0, size);

                PopulateTable(data, "Physical", physicalSizes, size);
                PopulateTable(data, "Attack", attackSizes, size);
                PopulateTable(data, "Resist", resistSizes, size);
                PopulateTable(data, "Movement", movementSizes, size);
            }

            SetFields("Attack");

            return dsParamData;
        }
        #endregion
        #region Save Data
        public void SaveParamData(string fileName, DataSet dsSourceData)
        {
            using (FileStream stream = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                try
                {
                    BinaryWriter writer = new BinaryWriter(stream);

                    foreach (string tableName in paramTables)
                    {
                        List<int> fieldSizes = GetFieldSizesForTable(tableName);
                        int startCol = dsSourceData.Tables[tableName].Columns.Count - fieldSizes.Count;
                        int fieldSizePosition;
                        foreach (DataRow drAmendedData in dsSourceData.Tables[tableName].Rows)
                        {
                            fieldSizePosition = 0;
                            byte[] byteValue = null;

                            /*if(tableName == "Attack")
                            {
                                drAmendedData["Angle X"] = Convert.ToUInt32(Convert.ToSingle(drAmendedData["Angle X"]) * 182.0416666666667).ToString();
                            }*/

                            for (int colPos = startCol; colPos < dsSourceData.Tables[tableName].Columns.Count; colPos++)
                            {
                                // Write Single data types to file
                                if (dsSourceData.Tables[tableName].Columns[colPos].DataType == typeof(System.Single))
                                {
                                    byteValue = BitConverter.GetBytes(Convert.ToSingle(drAmendedData[colPos]));
                                    for (int i = 0; i < Convert.ToInt16(fieldSizes[fieldSizePosition]); i++)
                                    {
                                        stream.WriteByte(byteValue[i]);
                                    }
                                }
                                // Write any other data types to file
                                else
                                {
                                    byteValue = BitConverter.GetBytes(Convert.ToUInt32(drAmendedData[colPos]));
                                    for (int i = 0; i < Convert.ToInt16(fieldSizes[fieldSizePosition]); i++)
                                    {
                                        stream.WriteByte(byteValue[i]);
                                    }
                                }
                                fieldSizePosition++;
                            }
                        }
                    }
                }
                finally
                {
                    stream.Close();
                }
            }
        }
        #endregion
        #region Data Processing
        private void PopulateTable(byte[] data, string TableName, List<int> fieldSizes, int size)
        {
            TableLocation tableLocation = LookupTableLocation(TableName, size);
            DataTable dtTable = dsParamData.Tables[TableName];
            int startColumn = dtTable.Columns.Count - fieldSizes.Count;
            int dataLength = 0;

            //Calculate the total number of bytes for the data to populate the DataTable with
            for (int i = 0; i < fieldSizes.Count; i++)
            {
                dataLength += Convert.ToInt32(fieldSizes[i]);
            }

            for (int j = tableLocation.startPosition; j < tableLocation.endPosition; j++)
            {
                DataRow newRow = dtTable.NewRow();
                int fieldPos = 0;
                newRow["Offset"] = j;
                for (int k = 0; k < fieldSizes.Count; k++)
                {
                    newRow[k + startColumn] = GetValue(data, j + fieldPos, Convert.ToInt32(fieldSizes[k]), dtTable.Columns[k + startColumn].DataType);
                    fieldPos += Convert.ToInt32(fieldSizes[k]);
                }
                j += (dataLength - 1);
                dtTable.Rows.Add(newRow);
            }
            SetAdditionalColumns(TableName);
        }

        public void AddTable(string TableName, List<int> fieldSizes)
        {
            DataTable dtTable = dsParamData.Tables[TableName];
            int startColumn = dtTable.Columns.Count - fieldSizes.Count;
            int dataLength = 0;

            //Calculate the total number of bytes for the data to populate the DataTable with
            for (int i = 0; i < fieldSizes.Count; i++)
            {
                dataLength += Convert.ToInt32(fieldSizes[i]);
            }

            for (int j = 0; j < 96; j++)
            {
                DataRow newRow = dtTable.NewRow();
                newRow["Offset"] = 0;
                for (int k = 0; k < fieldSizes.Count; k++)
                {
                    newRow[k + startColumn] = GetDefaultValue(Convert.ToInt32(fieldSizes[k]), dtTable.Columns[k + startColumn].DataType);
                }
                dtTable.Rows.Add(newRow);
            }
            SetAdditionalColumns(TableName);
        }

        private TableLocation LookupTableLocation(string TableName, int size)
        {
            TableLocation tableLocation = new TableLocation();
            DataRow[] drMatchingStartRows;
            DataRow[] drMatchingEndRows;
            string endTableName = "";

            drMatchingStartRows = dsParamData.Tables["Pointers"].Select("[Table name] = '" + TableName + "'");
            if (drMatchingStartRows.Length > 0)
                tableLocation.startPosition = Convert.ToInt32(drMatchingStartRows[0]["Table address"]);
            else tableLocation.startPosition = 0;

            if (TableName == "Physical")
                endTableName = "Attack";
            else if (TableName == "Attack")
                endTableName = "Resist";
            else if (TableName == "Resist")
                endTableName = "Movement";
            else if (TableName == "Movement")
                endTableName = "";

            if (endTableName == "") tableLocation.endPosition = size;
            else
            {
                drMatchingEndRows = dsParamData.Tables["Pointers"].Select("[Table name] = '" + endTableName + "'");
                if (drMatchingStartRows.Length > 0)
                    tableLocation.endPosition = Convert.ToInt32(drMatchingEndRows[0]["Table address"]);
                else tableLocation.endPosition = 0;
            }
            return tableLocation;
        }

        private List<int> GetFieldSizesForTable(string tableName)
        {
            List<int> fieldSizes = new List<int>();

            switch (tableName)
            {
                case "Physical":
                    fieldSizes = physicalSizes;
                    break;
                case "Attack":
                    fieldSizes = attackSizes;
                    break;
                case "Resist":
                    fieldSizes = resistSizes;
                    break;
                case "Movement":
                    fieldSizes = movementSizes;
                    break;
            }
            return fieldSizes;
        }

        private object GetValue(byte[] data, int offset, int length, System.Type dataType)
        {
            object rv = null;

            switch (length)
            {
                case 1:
                    if (dataType == typeof(System.SByte))
                    {
                        rv = (sbyte)data[offset];
                    }
                    else
                        rv = data[offset];
                    break;
                case 2:
                    if (dataType == typeof(System.String))
                    {
                        byte bit1 = data[offset];
                        byte bit2 = data[offset + 1];
                        rv = string.Format("{0:X2}", bit1) + string.Format("{0:X2}", bit2);
                    }
                    else if (dataType == typeof(System.UInt16))
                        rv = BitConverter.ToUInt16(data, offset);
                    else
                        rv = BitConverter.ToInt16(data, offset);
                    break;
                case 3:
                    if (dataType == typeof(System.String))
                    {
                        byte bit1 = data[offset];
                        byte bit2 = data[offset + 1];
                        byte bit3 = data[offset + 2];
                        rv = string.Format("{0:X2}", bit1) + string.Format("{0:X2}", bit2) + string.Format("{0:X2}", bit3);
                    }
                    else
                        rv = ConvertBytesToInt32(data, offset, 3);
                    break;
                case 4:
                    if (dataType == typeof(System.Int32))
                        rv = BitConverter.ToInt32(data, offset);
                    else if (dataType == typeof(System.UInt32))
                        rv = BitConverter.ToUInt32(data, offset);
                    else if (dataType == typeof(System.Single))
                    {
                        if (dataType == typeof(System.Single)) rv = BitConverter.ToSingle(data, offset);
                    }
                    else if (dataType == typeof(System.String))
                    {
                        byte bit1 = data[offset];
                        byte bit2 = data[offset + 1];
                        byte bit3 = data[offset + 2];
                        byte bit4 = data[offset + 3];
                        rv = string.Format("{0:X2}", bit1) + string.Format("{0:X2}", bit2) + string.Format("{0:X2}", bit3) + string.Format("{0:X2}", bit4);
                    }
                    break;
            }
            return rv;
        }

        private object GetDefaultValue(int length, System.Type dataType)
        {
            object rv = null;

            switch (length)
            {
                case 1:
                    if (dataType == typeof(System.SByte))
                    {
                        rv = (sbyte)0;
                    }
                    else
                        rv = 0;
                    break;
                case 2:
                    if (dataType == typeof(System.String))
                    {
                        byte bit1 = 0;
                        byte bit2 = 0;
                        rv = string.Format("{0:X2}", bit1) + string.Format("{0:X2}", bit2);
                    }
                    else if (dataType == typeof(System.UInt16))
                        rv = Convert.ToUInt16(0);
                    else
                        rv = Convert.ToInt16(0);
                    break;
                case 3:
                    if (dataType == typeof(System.String))
                    {
                        byte bit1 = 0;
                        byte bit2 = 0;
                        byte bit3 = 0;
                        rv = string.Format("{0:X2}", bit1) + string.Format("{0:X2}", bit2) + string.Format("{0:X2}", bit3);
                    }
                    else
                        rv = Convert.ToInt32(0);
                    break;
                case 4:
                    if (dataType == typeof(System.Int32))
                        rv = Convert.ToInt32(0);
                    else if (dataType == typeof(System.UInt32))
                        rv = Convert.ToUInt32(0);
                    else if (dataType == typeof(System.Single))
                    {
                        if (dataType == typeof(System.Single)) rv = Convert.ToSingle(0);
                    }
                    else if (dataType == typeof(System.String))
                    {
                        byte bit1 = 0;
                        byte bit2 = 0;
                        byte bit3 = 0;
                        byte bit4 = 0;
                        rv = string.Format("{0:X2}", bit1) + string.Format("{0:X2}", bit2) + string.Format("{0:X2}", bit3) + string.Format("{0:X2}", bit4);
                    }
                    break;
            }
            return rv;
        }

        private Int32 ConvertBytesToInt32(byte[] data, int offset, int length)
        {
            byte[] fieldValue = new byte[length];
            StringBuilder hexValue = new StringBuilder();

            for (int i = 0; i < length; i++)
            {
                fieldValue[i] = data[offset + i];
            }

            for (int j = length - 1; j >= 0; j--)
            {
                hexValue.Append(string.Format("{0:X2}", fieldValue[j]));
            }
            return Convert.ToInt32(hexValue.ToString(), 16);
        }

        public void SetAdditionalColumns(string tableName)
        {
            int index = 0;
            int difficulty = 0;
            int tableType = 0;
            if (tableName == "Physical") tableType = 0;
            else if (tableName == "Resist") tableType = 1;
            else if (tableName == "Attack") tableType = 2;
            else if (tableName == "Movement") tableType = 3;
            else return;
            foreach (DataRow dr in dsParamData.Tables[tableName].Rows)
            {
                if (index >= 96) { index = 0; difficulty++; }
                if (episode == 0) dr["Enemy Name"] = ep1Names[tableType][index];
                else if (episode == 1) dr["Enemy Name"] = ep2Names[tableType][index];
                else if (episode == 2) dr["Enemy Name"] = ep4Names[tableType][index];
                dr["Difficulty"] = difficulty;
                dr.EndEdit();
                index++;
            }
        }
        public void SetEpisode(int ep)
        {
            episode = ep;
        }

        private void SetFields(string TableName)
        {
            DataTable dtTable = dsParamData.Tables[TableName];
            if(TableName == "Attack")
            {
                foreach (DataRow dr in dtTable.Rows)
                {
                    dr["Angle X "] = Convert.ToSingle(dr["Angle X"]) / 182.0416666666667;
                }
            }
        }

        public bool CopyTable(string from, string to, IList<string> strList)
        {
            try
            {
                int _from = strList.IndexOf(from);
                int _to = strList.IndexOf(to);

                for(int i = 0; i < paramTables.Count; i++)
                {
                    DataRow[] drMatchingFromRows = dsParamData.Tables[paramTables[i]].Select("[Difficulty] = '" + _from + "'");
                    DataRow[] drMatchingToRows = dsParamData.Tables[paramTables[i]].Select("[Difficulty] = '" + _to + "'");
                    
                    if (drMatchingFromRows.Length != 96 || drMatchingToRows.Length != 96)
                        return false;
                    else
                    {
                        for(int j = 0; j < 96; j++)
                        {
                            for (int k = 3; k < dsParamData.Tables[paramTables[i]].Columns.Count; k++)
                            {
                                drMatchingToRows[j][k] = drMatchingFromRows[j][k];
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error copying table data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return true;
        }
        #endregion
    }
}
