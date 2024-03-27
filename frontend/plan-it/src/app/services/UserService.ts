import axios from "axios";
import { BACKEND_URL as BACKEND_URL } from "../utils/config";
import { User } from "../models/User";


const controllerUrl = `${BACKEND_URL}api/User`;

export async function GetAll(): Promise<User[]> {
  try {
    const response = await axios.get(
      `${controllerUrl}/GetAll`
    );
    const responseData = response.data;

    const usersData = responseData.users;

    const users = usersData.map((userData: any): User => {
      return {
        id: userData.id,
        userName: userData.userName,
        email: userData.email,
      };
    });

    // Return the array of teams
    return users;
  } catch (error) {
    console.error("Error fetching teams from backend:", error);
    throw error;
  }
}

export async function GetById(id: string): Promise<User> {
  try {
    const response = await axios.get(
      `${controllerUrl}/GetById?Id=${id}`
    );
    const userData = response.data.user;
    return {
      id: userData.id,
      userName: userData.userName,
      email: userData.email,
    };
  } catch (error: Error | any) {
    throw new Error("Error fetching user from backend ", error);
  }
}

export async function DeleteUser(id: string): Promise<void> {
  await axios.delete(
    `${controllerUrl}/Delete?Id=${id}`
  );
}

export async function UpdateUser(user: User): Promise<void> {
  const { id, email, userName: username } = user;
  const response = await axios.put(
    `${controllerUrl}/Update`,
    {
      id: id,
      email: email,
      fullname: username,
    }
  );
}

export async function AddUserToTeam(
  userId: string,
  teamId: string
): Promise<void> {
  await axios.put(`${controllerUrl}/AddUserToTeam`, {
    userId: userId,
    teamId: teamId,
  });
}

export async function RemoveUserFromTeam(
  userId: string,
  teamId: string
): Promise<void> {
  await axios.put(
    `${controllerUrl}/RemoveUserFromTeam`,
    {
      userId: userId,
      teamId: teamId,
    }
  );
}