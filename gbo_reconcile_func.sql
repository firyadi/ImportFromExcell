USE [GlobalBO]
go

-- EXEC [recon].[gbo_reconcile_func]

IF OBJECT_ID('[recon].[gbo_reconcile_func]')>0
     DROP PROCEDURE [recon].[gbo_reconcile_func]
GO


-- ==========================================================================================================================
-- Author     :	PSHK
-- Create date: 20210517
-- Description:	
-- ==========================================================================================================================

CREATE PROCEDURE [recon].[gbo_reconcile_func]
                 AS


DECLARE 
	@ReconName VARCHAR(255) = 'PSHK_PCI_RECON_UAT_2',
	@TradeDate DATETIME = '2021-01-20',
	@CompanyId INT, 
	@ReconId INT,
	@OutMsg varchar(max)

SET NOCOUNT ON

SELECT @CompanyId = GlValue FROM setup.Tb_GlobalValues WHERE GlType = 'DefaultCompany'
PRINT '@CompanyId = ' + ISNULL(CAST(@CompanyId AS VARCHAR),'<null>')

SELECT @ReconId = ReconId FROM recon.Tb_ReconMaster WHERE CompanyId = @CompanyId and ReconName = @ReconName
PRINT '@ReconId = ' + ISNULL(CAST(@ReconId AS VARCHAR),'<null>')

EXEC [recon].[TS_ProcessRecon] 	
	    @iintCompanyId = @CompanyId, 
	    @iintReconId = @ReconId, 
	    @idteTradeDate = @TradeDate, 
	    @ostrReturnMessage = @OutMsg OUTPUT


PRINT '@OutMsg='
PRINT @OutMsg
SET NOCOUNT OFF


