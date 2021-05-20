# ImportFromExcell

Application form in Pages Folder.
1. frmB0106 --> Import B0106 from MS Excel
2. frmPci  --> Import PCI data from MS Excel
3. frmProcess --> Process Data B0106 & PCI.
4. frmReconResult --> Display data from table Tb_ReconResult & user can exsport to Excell
5. frmReconSummary --> Display data from table Tb_ReconSummary & user can exsport to Excell

Database Setting
On file Web.config
1. DefaultConnection to connect Database: GlobalBORpt
2. GlobalBOConnection to connect Database: GlobalBO

Store Procedure
1. gbo_reconcile_func --> Process data
