using System;

namespace ServicesWebMvc.Models.ViewModels
    {
    public class ErrorViewModel
        {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
        }
    }