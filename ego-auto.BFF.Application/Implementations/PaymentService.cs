﻿using ego_auto.BFF.Application.Contracts;

namespace ego_auto.BFF.Application.Implementations;

public class PaymentService(IPaymentRepository _paymentRepository) : IPaymentService
{
}
