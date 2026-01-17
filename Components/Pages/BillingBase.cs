using billing.Models;
using Microsoft.AspNetCore.Components;
using Radzen;
using System.Collections.Generic;
using System.Text.RegularExpressions; 

namespace BillingSystem.Components.Pages
{
    public class BillingBase : ComponentBase
    {
        [Inject]
        protected NotificationService NotificationService { get; set; }

        protected string PhoneNumber { get; set; } = "";
        protected bool ShowResults { get; set; } = false;
        protected List<BillingInfo> billingList = new List<BillingInfo>();

        protected HashSet<string> PaidBills = new HashSet<string>();

        protected bool IsBillPaid(BillingInfo item)
        {
            return PaidBills.Contains(item.month);
        }

        protected void Search()
        {
            if (string.IsNullOrWhiteSpace(PhoneNumber) || !Regex.IsMatch(PhoneNumber, @"^\d{10}$"))
            {
                NotificationService.Notify(new NotificationMessage
                {
                    Severity = NotificationSeverity.Error,
                    Summary = "خطأ",
                    Detail = "رقم الهاتف يجب أن يتكون من 10 أرقام فقط.",
                    Duration = 4000
                });
                return;
            }

            PaidBills.Clear();

            billingList = new List<BillingInfo>
            {
                new BillingInfo
                {
                    month = "2025-10",
                    amount = 23.4m,
                    Cost = 23.634m,
                    IdNo = null,
                    disable_manualpay = false
                },
                new BillingInfo
                {
                    month = "2025-11",
                    amount = 46.6m,
                    Cost = 47.066m,
                    IdNo = "123456789",
                    disable_manualpay = false
                }
            };

            ShowResults = true;
        }

        protected void PayInstant(BillingInfo item)
        {
            if (string.IsNullOrWhiteSpace(item.IdNo) || !Regex.IsMatch(item.IdNo, @"^\d{9}$"))
            {
                NotificationService.Notify(new NotificationMessage
                {
                    Severity = NotificationSeverity.Warning,
                    Summary = "تنبيه",
                    Detail = "رقم الهوية يجب أن يتكون من 9 أرقام بالضبط.",
                    Duration = 4000
                });
                return;
            }

            PaidBills.Add(item.month);

            NotificationService.Notify(new NotificationMessage
            {
                Severity = NotificationSeverity.Success,
                Summary = "تم الدفع",
                Detail = "تمت عملية الدفع الفوري بنجاح.",
                Duration = 4000
            });
        }

        protected void PayManual(BillingInfo item)
        {
            PaidBills.Add(item.month);

            NotificationService.Notify(new NotificationMessage
            {
                Severity = NotificationSeverity.Success,
                Summary = "تم الدفع",
                Detail = "تم تحويل العملية للدفع اليدوي بنجاح.",
                Duration = 4000
            });
        }
    }
}