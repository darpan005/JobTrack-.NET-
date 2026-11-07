import React, {useState} from "react";
import  {useNavigate} from "react-router-dom";
import api from "../api/axiosInstance";
import "../styles/Auth.css";

const Register = () => {
    const [formData, setFormData] = useState({name: "", email: "", password:""});
    const [error, setError] = useState("");
    const [success, setSuccess] = useState("");
    const navigate = useNavigate();

    const handleSubmit = async (e) => {
        e.preventDefault();
        setError("");
        setSuccess("");
        try{
            await api.post("/auth/register", formData);
            setSuccess("Account Created Successfully!");
            setTimeout( () => navigate("/login"), 1500);
        } catch (err) {
            setError(err.response?.data?.message || "Registeration failed. Enter valid data.");
        }
    };

    return(
        <div>
            <div>
                <h2>Create Account</h2>

                {error && <div>{error}</div>}
                {success && <div>{success}</div>}

                <form onChange={handleSubmit}>
                    <div>
                        <label>Full Name</label>
                        <input 
                        type="text"
                        required
                        value={formData.name}
                        onChange={(e) => setFormData({...formData, name: e.target.value})}
                        placeholder="Enter your Full Name..."
                        />
                    </div>

                    <div>
                        <label>Email Address</label>
                        <input 
                        type="text"
                        required
                        value={formData.email}
                        onChange={(e) => setFormData({...formData, email: e.target.value})}
                        placeholder="Enter Your Email Address..." 
                        />
                    </div>

                    <div>
                        <label> Password </label>
                        <input 
                        type="text" 
                        required
                        value={formData.password}
                        onChange={(e)=> setFormData({...formData, password: e.target.value})}
                        />
                    </div>

                    <button type="submit">Create Account</button>
                </form>

                <p>Already Have an Account? <Link to="/login">Login Here</Link></p>
            </div>
        </div>
    );
};

export default Register;