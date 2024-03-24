export default function Header() { 
    return (
        <div className="d-flex justify-content-between align-items-center p-2 pe-4 ps-4 bg-black">
            <h3>Plan-it</h3>
            <div>
                <button className="btn btn-primary me-2">Login</button>
                <button className="btn btn-secondary ms-2">Sign up</button>
            </div>
        </div>
    );
}