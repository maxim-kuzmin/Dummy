<script setup lang="ts">
  import { getAppAboutPageService } from '~/utils/app/pages/about/app-about-page.service'
import { getAppFakePageService } from '~/utils/app/pages/fake/app-fake-page.service'

  const _this = (function (appAboutPageService, appFakePageService) {
    return {
      appAboutPageService,
      appFakePageService,
    }
  })(getAppAboutPageService(), getAppFakePageService())

  const aboutPageUrl = usePageUrl(
    _this.appAboutPageService.createPageUrlOptions(),
  )

  const fakePageUrl1 = usePageUrl(
    _this.appFakePageService.createPageUrlOptions({
      id: '1',
      pageNumber: 1
    }),
  )

  const fakePageUrl1pn2 = usePageUrl(
    _this.appFakePageService.createPageUrlOptions({
      id: '1',
      pageNumber: 2
    }),
  )

  const fakePageUrl2 = usePageUrl(
    _this.appFakePageService.createPageUrlOptions({
      id: '2',
      pageNumber: 1
    }),
  )
</script>

<template>
  <nav class="app-nav">
    <ul>
      <li>
        <NuxtLink :to="aboutPageUrl">About</NuxtLink>
      </li>
      <li>
        <NuxtLink :to="fakePageUrl1">Fake1</NuxtLink>
      </li>
      <li>
        <NuxtLink :to="fakePageUrl1pn2">Fake1pn2</NuxtLink>
      </li>
      <li>
        <NuxtLink :to="fakePageUrl2">Fake2</NuxtLink>
      </li>
      <li>
        <a href="#">11111</a>
        <ul>
          <li><a href="#">11111-1</a></li>
          <li><a href="#">11111-2</a></li>
          <li>
            <a href="#">11111-3</a>
            <ul>
              <li><a href="#">11111-3-1</a></li>
              <li><a href="#">11111-3-2</a></li>
              <li>
                <a href="#">11111-3-3</a>
                <ul>
                  <li><a href="#">11111-3-3-1</a></li>
                  <li><a href="#">11111-3-3-2</a></li>
                  <li><a href="#">11111-3-3-3</a></li>
                  <li><a href="#">11111-3-3-4</a></li>
                  <li><a href="#">11111-3-3-5</a></li>
                </ul>
              </li>
              <li><a href="#">11111-3-4</a></li>
              <li><a href="#">11111-3-5</a></li>
            </ul>
          </li>
          <li><a href="#">11111-4</a></li>
          <li><a href="#">11111-5</a></li>
        </ul>
      </li>
      <li>
        <a href="#">22222</a>
        <ul>
          <li><a href="#">22222-1</a></li>
          <li><a href="#">22222-2</a></li>
          <li>
            <a href="#">22222-3</a>
            <ul>
              <li><a href="#">22222-3-1</a></li>
              <li><a href="#">22222-3-2</a></li>
              <li data-selected>
                <a href="#">22222-3-3</a>
                <ul>
                  <li><a href="#">22222-3-3-1</a></li>
                  <li><a href="#">22222-3-3-2</a></li>
                  <li>
                    <a href="#">22222-3-3-3</a>
                    <ul>
                      <li><a href="#">22222-3-3-1</a></li>
                      <li><a href="#">22222-3-3-2</a></li>
                      <li><a href="#">22222-3-3-3</a></li>
                      <li><a href="#">22222-3-3-4</a></li>
                      <li><a href="#">22222-3-3-5</a></li>
                    </ul>
                  </li>
                  <li><a href="#">22222-3-3-4</a></li>
                  <li><a href="#">22222-3-3-5</a></li>
                </ul>
              </li>
              <li><a href="#">22222-3-4</a></li>
              <li><a href="#">22222-3-5</a></li>
            </ul>
          </li>
          <li><a href="#">22222-4</a></li>
          <li><a href="#">22222-5</a></li>
        </ul>
      </li>
      <li><a href="#">33333</a></li>
      <li><a href="#">44444</a></li>
      <li><a href="#">55555</a></li>
    </ul>
  </nav>
</template>
