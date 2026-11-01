import React, { createContext, useState, useEffect } from "react";
import { jwtDecode } from "jwt-decode";

export const AuthContext = createContext();

export const AuthProvider = ({ children }) => {
  const [user, setUser] = useState(null);
  const [token, setToken] = useState(localStorage.getItem("token"));
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    if (token) {
      try {
        const decoded = jwtDecode(token);
        // Token expiration check
        if (decoded.exp * 1000 < Date.now()) {
          logout();
        } else {
          setUser({
            id:
              decoded[
                "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"
              ] || decoded.nameid,
            name:
              decoded[
                "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"
              ] ||
              decoded.unique_name ||
              decoded.name,
            email:
              decoded[
                "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress"
              ] || decoded.email,
            role:
              decoded[
                "http://schemas.microsoft.com/ws/2008/06/identity/claims/role"
              ] || decoded.role,
          });
        }
      } catch (err) {
        logout();
      }
    } else {
      setUser(null);
    }
    setLoading(false);
  }, [token]);

  const login = (newToken) => {
    localStorage.setItem("token", newToken);
    setToken(newToken);
  };

  const logout = () => {
    localStorage.removeItem("token");
    setToken(null);
    setUser(null);
  };

  return (
    <AuthContext.Provider value={{ user, token, login, logout, loading }}>
      {!loading && children}
    </AuthContext.Provider>
  );
};
