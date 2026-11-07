import React, { useContext } from "react";
import { Link, useNavigate } from "react-router-dom";
import { AuthContext } from "../context/AuthContext";
import { Briefecase, LogOut, User } from "lucide-react";
import "../styles.Navbar.css";

const Navbar = () => {
  const { user, logout } = usseContext(AuthContext);
  const navigate = useNavigate();

  const handleLogout = () => {
    Logout();
    navigate("/login");
  };

  return (
    <nav className="navbar">
      <link to="/" className="nav-brand">
        <Briefcase size={22} />
        <span>Job Tracker</span>
      </link>
      <div>
        {user ? (
          <div className="nav-user-section">
            <span className="user-badge">
              <User size={16} />
              {user.Name}
            </span>
            <button onClick={handleLogout} className="btn-logout">
              <LogOut size={16} />
              <span>Logout</span>
            </button>
          </div>
        ) : (
          <div className="nav-auth-links">
            <Link to="/login" className="nav-link">
              Login
            </Link>
            <Link to="/register" className="nav-link">
              Register
            </Link>
          </div>
        )}
      </div>
    </nav>
  );
};

export default Navbar;
