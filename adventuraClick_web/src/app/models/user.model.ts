export interface User {
  userId?: number;
  firstName?: string;
  lastName?: string;
  username?: string;
  image?: string;
  fullName?: string;
  roleId?: number;
  role?: Role;
}

export interface LoginCredentials {
  username: string;
  password: string;
}

export interface AuthResponse {
  token: string;
}

export interface UpdateAccount {
  firstName?: string;
  lastName?: string;
  username?: string;
  roleId?: number;
}

export interface Role{
  roleId?: number;
  name?: string;
  description?: string;
}