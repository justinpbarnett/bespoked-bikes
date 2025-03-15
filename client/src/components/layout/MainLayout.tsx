import { Outlet } from "react-router-dom";
import { MainNav } from "./main-nav";

export default function MainLayout() {
  return (
    <div className="flex min-h-screen flex-col">
      <MainNav />
      <main className="flex-1 bg-background/5 p-6 mx-auto w-full max-w-7xl">
        <div className="rounded-lg bg-card p-8 shadow-sm">
          <Outlet />
        </div>
      </main>
    </div>
  );
}
