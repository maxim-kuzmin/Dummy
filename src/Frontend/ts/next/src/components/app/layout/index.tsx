import AppHeader from '../header'
import AppNav from '../nav'
import AppMain from '../main'
import AppFooter from '../footer'

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
