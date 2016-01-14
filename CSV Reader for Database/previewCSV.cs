using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSV_Reader_for_Database
{
    public partial class previewCSV : Form
    {
        public previewCSV()
        {
            InitializeComponent();
            //build tree
            TreeNode treeNode1 = new TreeNode("Tables");
            treeView1.Nodes.Add(treeNode1);
            TreeNode node2 = new TreeNode("AcctLog");
            TreeNode node3 = new TreeNode("Appointment");
            TreeNode node4 = new TreeNode("AppointmentMembers");
            TreeNode node5 = new TreeNode("AppointmentReps");
            TreeNode node6 = new TreeNode("AppointmentType");
            TreeNode node7 = new TreeNode("AppTrack");
            TreeNode node8 = new TreeNode("Appts");
            TreeNode node9 = new TreeNode("ARBalances");
            TreeNode node10 = new TreeNode("BankFile");
            TreeNode node11 = new TreeNode("bCheck");
            TreeNode node12 = new TreeNode("BigIntField");
            TreeNode node13 = new TreeNode("BillDOM");
            TreeNode node14 = new TreeNode("BLOB");
            TreeNode node15 = new TreeNode("CancelRule");
            TreeNode node16 = new TreeNode("CardList");
            TreeNode node17 = new TreeNode("ChargeTally");
            TreeNode node18 = new TreeNode("ChargeCode");
            TreeNode node19 = new TreeNode("Class");
            TreeNode node20 = new TreeNode("ClassCodes");
            TreeNode node21 = new TreeNode("ClassType");
            TreeNode node22 = new TreeNode("Codes");
            TreeNode node23 = new TreeNode("Codes2");
            TreeNode node24 = new TreeNode("CollChanges");
            TreeNode node25 = new TreeNode("CollPay");
            TreeNode node26 = new TreeNode("Company");
            TreeNode node27 = new TreeNode("ComparisonReports");
            TreeNode node28 = new TreeNode("ContractMember");
            TreeNode node29 = new TreeNode("Contracts");
            TreeNode node30 = new TreeNode("CtcCodes");
            TreeNode node31 = new TreeNode("CustomEmail");
            TreeNode node32 = new TreeNode("CycBill");
            TreeNode node33 = new TreeNode("DeletedReps");
            TreeNode node34 = new TreeNode("DeltaChargeTally");
            TreeNode node35 = new TreeNode("DigitalCalcTokens");
            TreeNode node36 = new TreeNode("DigitalContractLabels");
            TreeNode node37 = new TreeNode("DigitalContracts");
            TreeNode node38 = new TreeNode("DigitalCustomTokens");
            TreeNode node39 = new TreeNode("DigitalPrefillContract");
            TreeNode node40 = new TreeNode("DigitalPrefills");
            TreeNode node41 = new TreeNode("DigitalPrefillTokens");
            TreeNode node42 = new TreeNode("DoorTypes");
            TreeNode node43 = new TreeNode("Dtrans");
            TreeNode node44 = new TreeNode("Efts");
            TreeNode node45 = new TreeNode("EftsBatch");
            TreeNode node46 = new TreeNode("Emergency");
            TreeNode node47 = new TreeNode("EmpDept");
            TreeNode node48 = new TreeNode("ErrLog");
            TreeNode node49 = new TreeNode("EventDtrans");
            TreeNode node50 = new TreeNode("EventHDTrans");
            TreeNode node51 = new TreeNode("EventOnAcct");
            TreeNode node52 = new TreeNode("Flag");
            TreeNode node53 = new TreeNode("Frawarded");
            TreeNode node54 = new TreeNode("FRRULES");
            TreeNode node55 = new TreeNode("Gifts");
            TreeNode node56 = new TreeNode("GiftTrans");
            TreeNode node57 = new TreeNode("HDTrans");
            TreeNode node58 = new TreeNode("IAdjust");
            TreeNode node59 = new TreeNode("InOut");
            TreeNode node60 = new TreeNode("IntegerField");
            TreeNode node61 = new TreeNode("Locate");
            TreeNode node62 = new TreeNode("LocateTable");
            TreeNode node63 = new TreeNode("Lockers");
            TreeNode node64 = new TreeNode("Log");
            TreeNode node65 = new TreeNode("Logfile");
            TreeNode node66 = new TreeNode("LogInOutLog");
            TreeNode node67 = new TreeNode("Mailsu");
            TreeNode node68 = new TreeNode("MemberCard");
            TreeNode node69 = new TreeNode("MemberContracts");
            TreeNode node70 = new TreeNode("Members");
            TreeNode node71 = new TreeNode("MemberTransaction");
            TreeNode node72 = new TreeNode("MemMisc");
            TreeNode node73 = new TreeNode("MemPasswordArchive");
            TreeNode node74 = new TreeNode("Mempix");
            TreeNode node75 = new TreeNode("Memuse");
            TreeNode node76 = new TreeNode("MergeDocuments");
            TreeNode node77 = new TreeNode("MergeExtra");
            TreeNode node78 = new TreeNode("MergeFilters");
            TreeNode node79 = new TreeNode("MergeTokens");
            TreeNode node80 = new TreeNode("MobilinkUser");
            TreeNode node81 = new TreeNode("MPHis");
            TreeNode node82 = new TreeNode("OnAcct");
            TreeNode node83 = new TreeNode("PBCatCol");
            TreeNode node84 = new TreeNode("PBCatEdt");
            TreeNode node85 = new TreeNode("PBCatFMT");
            TreeNode node86 = new TreeNode("PBCattbl");
            TreeNode node87 = new TreeNode("PBCatVLD");
            TreeNode node88 = new TreeNode("PCCRESP");
            TreeNode node89 = new TreeNode("PCCSetup");
            TreeNode node90 = new TreeNode("PCCTrans");
            TreeNode node91 = new TreeNode("PendingCycle");
            TreeNode node92 = new TreeNode("PendingFamily");
            TreeNode node93 = new TreeNode("PendingMembers");
            TreeNode node94 = new TreeNode("PendingToken");
            TreeNode node95 = new TreeNode("PendingTokenAction");
            TreeNode node96 = new TreeNode("PendingTokenType");
            TreeNode node97 = new TreeNode("PFFrontDeskStats");
            TreeNode node98 = new TreeNode("PFTouchScreenButtons");
            TreeNode node99 = new TreeNode("PoS");
            TreeNode node100 = new TreeNode("PoSShift");
            TreeNode node101 = new TreeNode("PostFile");
            TreeNode node102 = new TreeNode("Ranges");
            TreeNode node103 = new TreeNode("RecurringClose");
            TreeNode node104 = new TreeNode("Referral");
            TreeNode node105 = new TreeNode("RegisterCodes");
            TreeNode node106 = new TreeNode("RemDoors");
            TreeNode node107 = new TreeNode("RemJobs");
            TreeNode node108 = new TreeNode("RemPorts");
            TreeNode node109 = new TreeNode("ReportSaves");
            TreeNode node110 = new TreeNode("RepPassword");
            TreeNode node111 = new TreeNode("Reps");
            TreeNode node112 = new TreeNode("RepTasks");
            TreeNode node113 = new TreeNode("RetPPost");
            TreeNode node114 = new TreeNode("Rights");
            TreeNode node115 = new TreeNode("Room");
            TreeNode node116 = new TreeNode("RoomClose");
            TreeNode node117 = new TreeNode("RoomCodes");
            TreeNode node118 = new TreeNode("RoomHours");
            TreeNode node119 = new TreeNode("RoomType");
            TreeNode node120 = new TreeNode("RuleClass");
            TreeNode node121 = new TreeNode("RuleLocation");
            TreeNode node122 = new TreeNode("Rules");
            TreeNode node123 = new TreeNode("SalesAnalysis");
            TreeNode node124 = new TreeNode("SalesReportingCategory");
            TreeNode node125 = new TreeNode("SentList");
            TreeNode node126 = new TreeNode("Series");
            TreeNode node127 = new TreeNode("SPCard");
            TreeNode node128 = new TreeNode("Statistics");
            TreeNode node129 = new TreeNode("StringField");
            TreeNode node130 = new TreeNode("TabApptTypes");
            TreeNode node131 = new TreeNode("TabRoomTypes");
            TreeNode node132 = new TreeNode("Tabs");
            TreeNode node133 = new TreeNode("TabTrainers");
            TreeNode node134 = new TreeNode("TanningBeds");
            TreeNode node135 = new TreeNode("TanningUse");
            TreeNode node136 = new TreeNode("Tasks");
            TreeNode node137 = new TreeNode("TrainerCode");
            TreeNode node138 = new TreeNode("TrainerSchedule");
            TreeNode node139 = new TreeNode("Updates");
            TreeNode node140 = new TreeNode("UseType");
            TreeNode node141 = new TreeNode("Vendor");
            TreeNode node142 = new TreeNode("WaitList");
            TreeNode node143 = new TreeNode("Workout");
            TreeNode node144 = new TreeNode("Xref");
            TreeNode node145 = new TreeNode("Xrefclub");
            TreeNode node146 = new TreeNode("Zipcode");


          

            //treeNode1 = new TreeNode("Dot Net Perls", dropdown1);
            //treeView1.Nodes.Add(treeNode1); ----this has to come after the array is made. 
            TreeNode[] dropdown1 = new TreeNode[] { node2, node3, node4, node5, node6, node7, node8, node9, node10, node11, node12, node13, node14, node15, node16, node17, node18, node19, node20, node21,
                node22, node23, node24, node25, node26, node27, node28, node29, node30, node31, node32, node33, node34, node35, node36, node37, node38, node39, node40, node41, node42, node43, node44, node45,
                node46, node47, node48, node49, node50, node51, node52, node53, node54, node55, node56, node57, node58, node59, node60, node61, node62, node63, node64, node65, node66, node67, node68,
                node69, node70, node71, node72, node73, node74, node75, node76, node77, node78, node79, node80, node81, node82, node83, node84, node85, node86, node87, node88, node89, node90, node91,
                node92, node93, node94, node95, node96, node97, node98, node99, node100, node101, node102, node103, node104, node105, node106, node107, node108, node109, node110, node111, node112,
                node113, node114, node115, node116, node117, node118, node119, node120, node121, node122, node123, node124, node125, node126, node127, node128, node129, node130, node131, node132, node133,
                node134, node135, node136, node137, node138, node139, node140, node141, node142, node143, node144, node145, node146};
            treeNode1 = new TreeNode("V6 Tables", dropdown1);
            treeView1.Nodes.Add(treeNode1);

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            
        }
    }
}
