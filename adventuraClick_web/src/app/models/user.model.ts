export interface User {
  userId: number;
  firstName: string;
  lastName: string;
  username: string;
  image: string;
  fullName: string;
  price: number;
}

export interface LoginCredentials {
  username: string;
  password: string;
}

export interface AuthResponse {
    token: string;
  }