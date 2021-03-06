USE [MMTShop]
GO
/****** Object:  StoredProcedure [dbo].[sp_getFeaturedProducts]    Script Date: 31/05/2021 10:48:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_getFeaturedProducts]

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT Id, SKU,[Name], [Description], Price, CategoryId, IsFeatured  FROM Product
	WHERE IsFeatured = 1
END
