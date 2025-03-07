﻿using Data.Contexts;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class UserInfoRepository(DataContext context) : BaseRepository<UserInfoEntity>(context), IUserInfoRepository
{
}


