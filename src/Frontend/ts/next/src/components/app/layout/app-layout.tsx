import AppHeader from '../header/app-header'
import AppNav from '../nav/app-nav'
import AppMain from '../main/app-main'
import AppFooter from '../footer/app-footer'

export default function AppLayout({
  children,
}: Readonly<{
  children: React.ReactNode;
}>) {
  return (
    <div className="app-layout">
      <AppHeader />
      <AppNav />
      <AppMain>{children}</AppMain>
      <AppFooter />
    </div>
  )
}
