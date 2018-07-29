Note that I (Stephen Wotton) have also submitted a Java test program which is available at: 
https://github.com/WottonParibasTest/BNP_Paribas_Test.git

This C# code is available at:
https://github.com/WottonParibasTest/AdditionalTestExampleCSharp.git
          
I wrote this to also demonstrate that I can also code in C#. Rather than just port the Java code I have taken the opportunity to show how the basis for a more extensible approach could be applied if it was expected that more types of offer were expected.  If no further types of offer were expected then the Java code is a simpler\quicker implimentation which would suffice.
          
Note that I have highlighted in the comments where appropriate how one would also achieve this in Java by using the Callable interface instead of delegates (function pointers).

This has been built with Visual Studio using .NET framework 4.6.1.

Based on the brief requirements I do not want to add unrequested functionality so am listing here my thoughts...
          
Assumptions and observations based on requirements:
(a) This is a very simple POS system where offers are applied to one product only and not across a range of products.
(b) A basket may have multiple enteries for the same item
(c) You may only buy discrete number of items, i.e. quantity is an integer, no loose items by weight are sold
(d) No user interface is required, the basket, products and offers may be hardcoded
(e) Prices do not vary over time and are only sold in Stirling.
(f) Only the offers detailed in the script may be supported.
(g) You can not put something in your basket which is not known.
(h) At most only one offer can be applied to a product.
(i) Output will follow usual receipt convention of:
	(1) Calculate amount without discount on all items and show total
	(2) Then apply discounts and show discount total
	(3) Then show total due
	(4) Assume order of products on the receipt is not important.
	(5) Based on Marks and Spencer receipt multiple items are listed individually.
         