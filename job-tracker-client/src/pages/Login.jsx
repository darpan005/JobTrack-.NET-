import React, {useState, useContext} from "react";
import { useNavigate} from "react-router-dom";
import {AuthContext} from "../context/AuthContext";
import api from "../api/axiosInstance";
import "../styles/Auth.css";

const Login = () => {
    const [formData, setFormData] = useState({email: "", password: ""});
    const [error, setError] =  useState("");
    const {login} = useContext(AuthContext);
    const navigate = useNavigate();

    const handleSubmit = async (e) => {
        e.preventDefault();
        setError("");
        try {
            const response = await api.post("/auth/login", formData);
            login(response.data.token);
            navigate("/");
        } catch (err) {
            setError(err.response?.data?.message || "Login failed. Enter valid data.")
        }
    };


    return(
        <div className="auth-container">
            <div className="auth-card">
                <h2 className="auth-title">Welcome Back</h2>

                {error && <div className="alert-message alert-error">{error}</div>}

                <form onSubmit={handleSubmit} className="auth-form">
                    <div className="form-group">
                        <label>Email Address</label>
                        <input
                            type="email"
                            required
                            value={formData.email}
                            onChange={(e) => setFormData({...formData, email: e.target.value})}
                            placeholder ="Enter your Email"
                        />
                    </div>

                    <div className="form-group">
                        <input
                            type="password"
                            required
                            value={formData.password}
                            onChange={(e) => setFormData({...formData, password: e.target.value})}
                            placeholder = "Enter Password"
                        />
                    </div>

                    <button type="submit" className="btn-primary">
                        Sign In
                    </button>
                </form>

                <p className="auth-footer">
                    Don't have an account? <Link to="/register"> Create Account</Link>
                </p>
            </div>
        </div>
    );
};

export default Login;