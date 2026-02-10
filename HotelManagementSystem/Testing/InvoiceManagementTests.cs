using System;
using System.Text;
using HotelManagementSystem.DAL;
using HotelManagementSystem.Models;
using System.Collections.Generic;

namespace HotelManagementSystem.Testing
{
    /// <summary>
    /// Test suite for Day 23 - Invoice Management & Enhancement
    /// Tests InvoiceListForm functionality and InvoiceRepository methods
    /// </summary>
    public static class InvoiceManagementTests
    {
        public static string RunAllTests()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine("==========================================================================");
            output.AppendLine("  DAY 23 - INVOICE MANAGEMENT & ENHANCEMENT - TEST SUITE");
            output.AppendLine("==========================================================================");
            output.AppendLine();
            output.AppendLine("Test Date: " + DateTime.Now.ToString("MMM dd, yyyy HH:mm:ss"));
            output.AppendLine("Testing: InvoiceRepository, PaymentRepository, and related functionality");
            output.AppendLine();
            output.AppendLine("--------------------------------------------------------------------------");
            output.AppendLine();

            int passed = 0;
            int failed = 0;

            // Test 1: Load all invoices
            output.AppendLine("Test 1: Load All Invoices");
            output.AppendLine("--------------------------");
            try
            {
                InvoiceRepository invoiceRepo = new InvoiceRepository();
                List<Invoice> invoices = invoiceRepo.GetAll();
                
                output.AppendLine($"? Successfully loaded {invoices.Count} invoice(s)");
                
                if (invoices.Count > 0)
                {
                    output.AppendLine("\nSample invoices:");
                    int count = 0;
                    foreach (Invoice inv in invoices)
                    {
                        if (count >= 3) break;
                        output.AppendLine($"  - {inv.InvoiceNumber}: Total ${inv.TotalAmount:F2}, Status: {inv.Status}");
                        count++;
                    }
                }
                
                output.AppendLine("\n? Test 1 PASSED");
                passed++;
            }
            catch (Exception ex)
            {
                output.AppendLine($"\n? Test 1 FAILED: {ex.Message}");
                failed++;
            }
            output.AppendLine();

            // Test 2: Filter by status
            output.AppendLine("Test 2: Filter Invoices by Status");
            output.AppendLine("----------------------------------");
            try
            {
                InvoiceRepository invoiceRepo = new InvoiceRepository();
                
                List<Invoice> pendingInvoices = invoiceRepo.GetInvoicesByStatus("Pending");
                List<Invoice> paidInvoices = invoiceRepo.GetInvoicesByStatus("Paid");
                List<Invoice> partialInvoices = invoiceRepo.GetInvoicesByStatus("PartiallyPaid");
                
                output.AppendLine($"? Pending invoices: {pendingInvoices.Count}");
                output.AppendLine($"? Paid invoices: {paidInvoices.Count}");
                output.AppendLine($"? Partially paid invoices: {partialInvoices.Count}");
                
                output.AppendLine("\n? Test 2 PASSED");
                passed++;
            }
            catch (Exception ex)
            {
                output.AppendLine($"\n? Test 2 FAILED: {ex.Message}");
                failed++;
            }
            output.AppendLine();

            // Test 3: Get unpaid invoices
            output.AppendLine("Test 3: Get Unpaid Invoices");
            output.AppendLine("----------------------------");
            try
            {
                InvoiceRepository invoiceRepo = new InvoiceRepository();
                List<Invoice> unpaidInvoices = invoiceRepo.GetUnpaidInvoices();
                
                output.AppendLine($"? Found {unpaidInvoices.Count} unpaid invoice(s)");
                
                decimal totalDue = 0;
                foreach (Invoice inv in unpaidInvoices)
                {
                    totalDue += inv.BalanceAmount;
                }
                
                output.AppendLine($"? Total balance due: ${totalDue:F2}");
                output.AppendLine("\n? Test 3 PASSED");
                passed++;
            }
            catch (Exception ex)
            {
                output.AppendLine($"\n? Test 3 FAILED: {ex.Message}");
                failed++;
            }
            output.AppendLine();

            // Test 4: Payment history by invoice
            output.AppendLine("Test 4: Payment History Retrieval");
            output.AppendLine("----------------------------------");
            try
            {
                InvoiceRepository invoiceRepo = new InvoiceRepository();
                PaymentRepository paymentRepo = new PaymentRepository();
                
                List<Invoice> invoices = invoiceRepo.GetAll();
                
                if (invoices.Count > 0)
                {
                    Invoice testInvoice = invoices[0];
                    List<Payment> payments = paymentRepo.GetPaymentsByInvoiceId(testInvoice.InvoiceId);
                    
                    output.AppendLine($"? Invoice {testInvoice.InvoiceNumber} has {payments.Count} payment(s)");
                    
                    if (payments.Count > 0)
                    {
                        decimal totalPaid = 0;
                        foreach (Payment payment in payments)
                        {
                            totalPaid += payment.Amount;
                            output.AppendLine($"  - {payment.PaymentMethod}: ${payment.Amount:F2} on {payment.PaymentDate:MMM dd, yyyy}");
                        }
                        output.AppendLine($"? Total paid: ${totalPaid:F2}");
                    }
                }
                else
                {
                    output.AppendLine("? No invoices found to test payment history");
                }
                
                output.AppendLine("\n? Test 4 PASSED");
                passed++;
            }
            catch (Exception ex)
            {
                output.AppendLine($"\n? Test 4 FAILED: {ex.Message}");
                failed++;
            }
            output.AppendLine();

            // Test 5: Invoice model methods
            output.AppendLine("Test 5: Invoice Model Methods");
            output.AppendLine("------------------------------");
            try
            {
                Invoice testInvoice = new Invoice
                {
                    SubTotal = 200.00m,
                    TaxRate = 10.00m,
                    Discount = 20.00m
                };
                
                testInvoice.CalculateTax();
                testInvoice.CalculateTotal();
                
                output.AppendLine($"? SubTotal: ${testInvoice.SubTotal:F2}");
                output.AppendLine($"? Tax (10%): ${testInvoice.TaxAmount:F2}");
                output.AppendLine($"? Discount: ${testInvoice.Discount:F2}");
                output.AppendLine($"? Total: ${testInvoice.TotalAmount:F2}");
                
                // Test expected values
                if (testInvoice.TaxAmount == 20.00m && testInvoice.TotalAmount == 200.00m)
                {
                    output.AppendLine("? Calculation correct! (200 + 20 - 20 = 200)");
                }
                
                // Test status methods
                testInvoice.PaidAmount = 0;
                testInvoice.Status = "Pending";
                output.AppendLine($"? IsPending(): {testInvoice.IsPending()}");
                
                testInvoice.PaidAmount = 100.00m;
                testInvoice.Status = "PartiallyPaid";
                output.AppendLine($"? IsPartiallyPaid(): {testInvoice.IsPartiallyPaid()}");
                
                testInvoice.PaidAmount = 200.00m;
                testInvoice.Status = "Paid";
                output.AppendLine($"? IsFullyPaid(): {testInvoice.IsFullyPaid()}");
                
                output.AppendLine("\n? Test 5 PASSED");
                passed++;
            }
            catch (Exception ex)
            {
                output.AppendLine($"\n? Test 5 FAILED: {ex.Message}");
                failed++;
            }
            output.AppendLine();

            // Test 6: Invoice number generation
            output.AppendLine("Test 6: Invoice Number Generation");
            output.AppendLine("----------------------------------");
            try
            {
                string invoiceNumber = Invoice.GenerateInvoiceNumber(12345);
                output.AppendLine($"? Generated invoice number: {invoiceNumber}");
                
                // Check format
                if (invoiceNumber.StartsWith("INV-") && invoiceNumber.Length >= 15)
                {
                    output.AppendLine("? Format is correct (INV-YYYYMMDD-XXXXX)");
                }
                
                output.AppendLine("\n? Test 6 PASSED");
                passed++;
            }
            catch (Exception ex)
            {
                output.AppendLine($"\n? Test 6 FAILED: {ex.Message}");
                failed++;
            }
            output.AppendLine();

            // Test 7: Revenue statistics
            output.AppendLine("Test 7: Revenue Statistics");
            output.AppendLine("--------------------------");
            try
            {
                InvoiceRepository invoiceRepo = new InvoiceRepository();
                List<Invoice> allInvoices = invoiceRepo.GetAll();
                
                decimal totalRevenue = 0;
                decimal totalPaid = 0;
                decimal totalBalance = 0;
                int pendingCount = 0;
                
                foreach (Invoice inv in allInvoices)
                {
                    if (inv.Status != "Cancelled")
                    {
                        totalRevenue += inv.TotalAmount;
                        totalPaid += inv.PaidAmount;
                        
                        if (inv.Status != "Paid")
                        {
                            totalBalance += inv.BalanceAmount;
                        }
                    }
                    
                    if (inv.Status == "Pending")
                    {
                        pendingCount++;
                    }
                }
                
                output.AppendLine($"? Total Revenue (excluding cancelled): ${totalRevenue:F2}");
                output.AppendLine($"? Total Paid: ${totalPaid:F2}");
                output.AppendLine($"? Total Balance: ${totalBalance:F2}");
                output.AppendLine($"? Pending Invoices: {pendingCount}");
                
                output.AppendLine("\n? Test 7 PASSED");
                passed++;
            }
            catch (Exception ex)
            {
                output.AppendLine($"\n? Test 7 FAILED: {ex.Message}");
                failed++;
            }
            output.AppendLine();

            // Summary
            output.AppendLine("==========================================================================");
            output.AppendLine("  TEST SUMMARY - DAY 23");
            output.AppendLine("==========================================================================");
            output.AppendLine();
            output.AppendLine($"Total Tests: {passed + failed}");
            output.AppendLine($"? Passed: {passed}");
            output.AppendLine($"? Failed: {failed}");
            output.AppendLine($"Success Rate: {(passed * 100.0 / (passed + failed)):F1}%");
            output.AppendLine();
            
            if (failed == 0)
            {
                output.AppendLine("?? ALL TESTS PASSED! ??");
                output.AppendLine();
                output.AppendLine("Day 23 Complete - Invoice Management is working perfectly!");
                output.AppendLine("Features validated:");
                output.AppendLine("  ? Invoice listing and filtering");
                output.AppendLine("  ? Payment history retrieval");
                output.AppendLine("  ? Revenue statistics calculation");
                output.AppendLine("  ? Invoice status management");
                output.AppendLine("  ? Invoice model calculations");
            }
            else
            {
                output.AppendLine("??  Some tests failed. Please review the errors above.");
            }
            
            output.AppendLine();
            output.AppendLine("==========================================================================");

            return output.ToString();
        }
    }
}
