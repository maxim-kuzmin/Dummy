import { reactive } from 'vue'
import { type paths } from '../api-types/russiabasket-types'

type TResult = {
	content: paths['/api/view/page/{tag}']['get']['responses']['200']['content']['application/json']['result']
}

type TBlocks = NonNullable<TResult['content']>['blocks']

type TPageState = {
	header: TBlocks,
	main: TBlocks,
	mainRight: TBlocks,
	footer: TBlocks,
}

const pageState = reactive<TPageState>({
	header: [],
	main: [],
	mainRight: [],
	footer: [],
})

export const usePageState = (content: TBlocks = []) => {
	if (content && content?.length > 0) {
		pageState.header = content.filter((i) => i.section === 'header')
		pageState.main = content.filter((i) => i.section === 'main')
		pageState.mainRight = content.filter((i) => i.section === 'mainRight')
		pageState.footer = content.filter((i) => i.section === 'footer')
	}

	function clearState() {
		pageState.header = []
		pageState.main = []
		pageState.mainRight = []
		pageState.footer = []
	}

	return { pageState, clearState }
}
