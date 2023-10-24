import { JwtHelperService } from '@auth0/angular-jwt';

export const getUserId = () => {
  const token = JSON.parse(localStorage.getItem('JWT') || '{}')?.token;

  if (!token) {
    console.error('Token not found in localStorage.');
    return null;
  }
  const helper = new JwtHelperService();
  const decodedToken = helper.decodeToken(token);
  const userId = decodedToken['userId'];
  return userId;
};
