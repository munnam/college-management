﻿using System;
using System.Collections.Generic;

namespace CollegeManagementSystem.Entities;

public partial class PaymentMode
{
    public int ModeId { get; set; }

    public string ModeName { get; set; } = null!;
}
